using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float minDmg = 80f;
    [SerializeField] float maxDmg = 120f;
    [SerializeField] int multiplierIncrease = 1;

    [Header("Camera Shake For collision")]

    [SerializeField] float shakeFrequency = 2f;
    [SerializeField] float shakeAmplitude = 2f;
    [SerializeField] float shakeTime = 1f;

    GameObject Vcam1; // if other cameras arise be sure to set this up so that it finds the active camera to use instead of setting it at start
    CameraShake cameraShakeScript;
    Multiplier multiplierScript;

    // Start is called before the first frame update
    void Start()
    {
        Vcam1 = GameObject.FindWithTag("Vcam1");
        cameraShakeScript = Vcam1.GetComponent<CameraShake>();
        multiplierScript = GameObject.FindWithTag("Multiplier").GetComponent<Multiplier>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>())
        {
            float dmg = Random.Range(minDmg, maxDmg);
            collision.GetComponent<Health>().TakeDamage(dmg); //Deals a random amount of damage between the two points
            cameraShakeScript.cameraShake(shakeFrequency, shakeAmplitude, shakeTime);
            if(collision.tag == "Enemy" && gameObject.tag == "Projectile")//if object hit is enemy set the increase to a positive number even if negative
            {
                multiplierIncrease /= -2;
                print(multiplierIncrease);
            }

            multiplierScript.IncreaseMultiplier(multiplierIncrease);
        }

        if (GetComponent<PlaySfxAtPoint>() == null) { return; }
        GetComponent<PlaySfxAtPoint>().PlaySFX();
    }
}
