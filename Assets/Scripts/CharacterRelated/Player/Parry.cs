using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField] GameObject rotator;
    [SerializeField] float speedAddedToParry = 2f;
    [SerializeField] int multiplierIncrease = 1;
    [SerializeField] AudioClip ParriedSFX;

    [Header("Camera Shake For collision")]

    [SerializeField] float shakeFrequency = 2f;
    [SerializeField] float shakeAmplitude = 2f;
    [SerializeField] float shakeTime = 1f;
    [SerializeField] int pointsForParry = 500;

    bool parryFrame = false;

    GameObject Vcam1; // if other cameras arise be sure to set this up so that it finds the active camera to use instead of setting it at start
    CameraShake cameraShakeScript;

    ScoreTotal scoreScript;
    Multiplier multiplierScript;
    CreateScoreUI textSpawnUIScript;

    // Start is called before the first frame update
    void Start()
    {
        Vcam1 = GameObject.FindWithTag("Vcam1");
        cameraShakeScript = Vcam1.GetComponent<CameraShake>();
        scoreScript = GameObject.FindWithTag("Score").GetComponent<ScoreTotal>();
        multiplierScript = GameObject.FindWithTag("Multiplier").GetComponent<Multiplier>();
        textSpawnUIScript = GameObject.FindWithTag("pointSpawner").GetComponent<CreateScoreUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            ParryAttk(collision);
        }
    }

    public void SetParryFrameTrue()
    {
        parryFrame = true;
    }

    public void SetParryFrameFalse()
    {
        parryFrame = false;
    }

    private void ParryAttk(Collider2D otherObject)
    {
        if(!parryFrame)
        {
            return;
        }

        if(otherObject.gameObject.tag == "Projectile")
        {
            //reflect bullet back in direction it came from
            otherObject.GetComponent<FlyTowardsPlayer>().ResetTarget(rotator, speedAddedToParry);
            cameraShakeScript.cameraShake(shakeFrequency, shakeAmplitude, shakeTime);//cameraShake

            //Play SFX
            AudioSource.PlayClipAtPoint(ParriedSFX, transform.position);

            otherObject.gameObject.layer = 14;
            scoreScript.AddScore(pointsForParry, gameObject.transform);
            multiplierScript.IncreaseMultiplier(multiplierIncrease);
        }
    }
}
