using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int deathPoints = 1000; // use a minus value for player so that points are lost on death
    [SerializeField] int multiplierIncrease = 2;
    [SerializeField] AudioClip hurt;

    public float healthPoints = 1000f;
    public float maxHealthPoints;
    public bool damageTaken = false;

    public bool dead = false;

    ScoreTotal scoreScript;
    LivesDisplay livesScript;
    Multiplier multiplierScript;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        multiplierScript = GameObject.FindWithTag("Multiplier").GetComponent<Multiplier>();
        scoreScript = GameObject.FindWithTag("Score").GetComponent<ScoreTotal>();
        livesScript = GameObject.FindWithTag("Lives").GetComponent<LivesDisplay>();
        maxHealthPoints = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            anim.SetTrigger("Die");
            if (gameObject.tag == "Player")
            {
                dead = true;
                return;
            }
            else
            {
                if (dead) { return; }
                AddPoints();
                multiplierScript.IncreaseMultiplier(multiplierIncrease);
            }
            dead = true;
        }
    }

    public void RemoveLifeFromDisplay()
    {
        livesScript.AlterLife(-1);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void AddPoints()
    {
        scoreScript.AddScore(deathPoints, gameObject.transform);
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;

        if(hurt != null)
        {
            AudioSource.PlayClipAtPoint(hurt, transform.position);
        }
        if (dead) { return; }
        damageTaken = true;
    }

    private void LateUpdate()
    {
        damageTaken = false;
    }
}
