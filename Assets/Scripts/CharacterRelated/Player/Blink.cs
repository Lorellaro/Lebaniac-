using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] float blinkSpeed = 100f;
    [SerializeField] Transform rotator;
    [SerializeField] float timeBtwDash = 2f;
    [SerializeField] float extraLineLifeTime = 0.05f;
    [SerializeField] GameObject VFX;

    [Header("Camera Shake For Dash")]
    [SerializeField] GameObject Vcam1; // if other cameras arise be sure to set this up so that it finds the active camera to use instead of setting it at start
    [SerializeField] float shakeFrequency = 2f;
    [SerializeField] float shakeAmplitude = 2f;
    [SerializeField] float shakeTime = 1f;


    Rigidbody2D rb;
    Vector2 dashInput;
    TrailRenderer trailRenderer;
    CameraShake cameraShakeScript;
    PlaySfxAtPoint playSfxScript;
    Animator anim;
    FreezeFrame freezeFrameScript;
    Health healthScript;

    float currentDashTime = 0;
    float stopLineTime = 0;

    public bool isBlinking;
    bool dashFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        freezeFrameScript = GetComponent<FreezeFrame>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        cameraShakeScript = Vcam1.GetComponent<CameraShake>();
        playSfxScript = GetComponent<PlaySfxAtPoint>();
        healthScript = GetComponent<Health>();
    }

    private void Update()
    {
        DashInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Dash();
    }

    private void Dash()
    {
        if(dashFrame)
        {
            rb.MovePosition(rb.transform.position + rotator.up * blinkSpeed * Time.deltaTime); // Dashes
            dashFrame = false; //REMOVE THIS LINE OF CODE TO SEE WHAT THE DEATH BY ONE THOUSAND CUTS LOOKS LIKE
        }
    }

    private void DashInput()
    {
        if (healthScript.dead) { return; }
        //trail render on and off set to 0.2 seconds after dash finishes
        if (stopLineTime > 0)
        {
            stopLineTime -= Time.deltaTime;
        }
        else
        {
            trailRenderer.emitting = false;
        }

        if (currentDashTime > 0f)//whilst player is dashing do this
        {
            anim.ResetTrigger("Dash");
            isBlinking = true;
            currentDashTime -= Time.deltaTime;
            anim.SetTrigger("Dash");
            return;
        }
        else
        {
            isBlinking = false;
            gameObject.layer = 8;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            dashInput = rotator.up;
            //set player layer to player dash
            gameObject.layer = 10;

            //Play VFX
            Instantiate(VFX, transform.position, transform.rotation);

            //Set Camera to shake
            cameraShakeScript.cameraShake(shakeFrequency, shakeAmplitude, shakeTime);

            anim.SetTrigger("Dash");
            isBlinking = true;

            currentDashTime = timeBtwDash;// Starts dash timer

            playSfxScript.PlaySFX(); // Plays SFX


        }
    }

    public void PlayVFX()
    {
        Instantiate(VFX, transform.position, transform.rotation);
    }

    public void DashFrame()
    {
        dashFrame = true;
        freezeFrameScript.freezeFrame();
        trailRenderer.emitting = true;// Begins trail renderer
        stopLineTime = currentDashTime + extraLineLifeTime; // starts lineTimer
    }
}
