using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfxAtPoint : MonoBehaviour
{
    [SerializeField] AudioClip audioFile;

    public void PlaySFX()
    {
        AudioSource.PlayClipAtPoint(audioFile, transform.position);
    }

}
