using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    [SerializeField] GameObject swordLight;
    [SerializeField] AudioClip swordSwingSFX;

    [Header("Camera Shake For Sword Swing")]

    [SerializeField] float shakeFrequency = 1f;
    [SerializeField] float shakeAmplitude = 1f;
    [SerializeField] float shakeTime = 1f;

    Animator animator;
    CameraShake cameraShakeScript;

    float currentAttkNum = 0;

    bool attacking = false;
    bool canCombo = true;
    bool playNextAnim = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraShakeScript = GameObject.FindWithTag("Vcam1").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (currentAttkNum == 1)
            {
                canCombo = true;
            }

            if (currentAttkNum == 0 && playNextAnim)
            {
                animator.Play("Swing");
                currentAttkNum = 1;
                canCombo = false;
                AudioSource.PlayClipAtPoint(swordSwingSFX, transform.position);
                cameraShakeScript.cameraShake(shakeFrequency, shakeAmplitude, shakeTime);//cameraShake
                playNextAnim = false;
            }

            else if((currentAttkNum == 1 && playNextAnim))
            {
                animator.Play("Swing2");
                currentAttkNum = 0;
                canCombo = false;
                AudioSource.PlayClipAtPoint(swordSwingSFX, transform.position);
                cameraShakeScript.cameraShake(shakeFrequency, shakeAmplitude, shakeTime);//cameraShake
                playNextAnim = false;
            }
        }

        else if(canCombo && currentAttkNum == 1 && playNextAnim)
        {
            animator.Play("Swing2");
            currentAttkNum = 0;
            AudioSource.PlayClipAtPoint(swordSwingSFX, transform.position);
            playNextAnim = false;
        }
    }

    public void PlayNextAnim()
    {
        playNextAnim = true;
    }

    public void canAttack()
    {
        gameObject.layer = 12;//Changes collider to attacking layer
        swordLight.SetActive(true);
        attacking = true;
    }

    public void stopAttacking()
    {
        gameObject.layer = 11;//Changes collider to Not Attacking layer
        swordLight.SetActive(false);
        attacking = false;
    }

    public void ResetCombo()
    {
        currentAttkNum = 0;
    }
}
