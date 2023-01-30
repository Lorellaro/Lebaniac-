using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePos;

    [SerializeField] float lowestFireTime = 3f;
    [SerializeField] float highestFireTime = 5f;

    float fireTime = 0f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        fireTime = Random.Range(lowestFireTime / 1.5f, highestFireTime / 1.5f);//Sets the first fire to half what it normally is
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()//Simple timer that calls the firebullet function continuosly 
    {
        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
            return;
        }

        else
        {
            fireBullet();
            fireTime = Random.Range(lowestFireTime, highestFireTime);
        }

    }

    public void InstantiateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    private void fireBullet()
    {
        animator.SetTrigger("Fire");
    }
}
