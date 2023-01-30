using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float lifeDuration = 1f;

    float startLifeDuration;

    private void Awake()
    {
        startLifeDuration = lifeDuration;
    }

    void Update()
    {
        if(lifeDuration > 0)
        {
            lifeDuration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetTimer()
    {
        lifeDuration = startLifeDuration;
    }

}
