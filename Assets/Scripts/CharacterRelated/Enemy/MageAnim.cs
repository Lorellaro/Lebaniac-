using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAnim : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePos;

    Animator animator;
    Health healthScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript.damageTaken)
        {
            animator.SetTrigger("Hit");
        }
    }

    public void InstantiateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    public void FireBullet()
    {
        animator.SetTrigger("Fire");
    }
}
