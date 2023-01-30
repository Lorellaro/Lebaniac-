using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisePos : MonoBehaviour
{
    [SerializeField] float minPos = -10;
    [SerializeField] float maxPos = 10;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2 (Random.Range(minPos, maxPos), Random.Range(minPos, maxPos));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
