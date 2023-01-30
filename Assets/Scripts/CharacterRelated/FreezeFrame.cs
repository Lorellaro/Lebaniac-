using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    //Code below Aided by https://www.youtube.com/watch?v=ji-2t_JLkB4 [1] in writeup document
    [SerializeField] float freezeFrameDuration = 1f;

    float currentFrameDuration = 0f;

    bool frozen = false;

    // Update is called once per frame
    void Update()
    {
        if(currentFrameDuration > 0 && !frozen)
        {
            StartCoroutine(Freeze());
        }
    }

    public void freezeFrame()
    {
        currentFrameDuration = freezeFrameDuration;
    }

    IEnumerator Freeze()
    {
        frozen = true;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(freezeFrameDuration);

        Time.timeScale = 1f;
        currentFrameDuration = 0f;
        frozen = false;
    }

}
