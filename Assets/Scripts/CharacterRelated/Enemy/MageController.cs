using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
    [SerializeField] float lowestFireTime = 3f;
    [SerializeField] float highestFireTime = 5f;

    float fireTime = 0f;

    MageAnim animatorScript;

    // Start is called before the first frame update
    void Start()
    {
        animatorScript = GetComponent<MageAnim>();
        fireTime = Random.Range(lowestFireTime / 1.5f, highestFireTime / 1.5f);//Sets the first fire to half what it normally is
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()//Simple timer that calls the firebullet function continuosly 
    {
        if(fireTime > 0)
        {
            fireTime -= Time.deltaTime;
            return;
        }

        else
        {
            animatorScript.FireBullet();
            fireTime = Random.Range(lowestFireTime, highestFireTime);
        }

    }
}
