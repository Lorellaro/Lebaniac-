using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Start() //ONLY ALLOWS ONE OF THE OBJECT TO EXIST AT A TIME
    {
        string currentTag = gameObject.tag;
        if(GameObject.FindGameObjectsWithTag(currentTag).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
