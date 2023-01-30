using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicToTitleScreen : MonoBehaviour
{
    [SerializeField] AudioClip titleScreenMusic;

    GameObject musicPlayerOBJ;
    AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayerOBJ = GameObject.FindWithTag("musicPlayer");
        musicPlayer = musicPlayerOBJ.GetComponent<AudioSource>();
        if(musicPlayer.clip == titleScreenMusic) { return; }
        PlayTitleScreenMusic();
    }

    public void PlayTitleScreenMusic()
    {
        StartCoroutine(WaitTillSilent());
        StartCoroutine(IncreaseVolumeToMax());
    }

    private IEnumerator WaitTillSilent()
    {
        while (musicPlayer.volume > 0)
        {
            musicPlayer.volume -= Time.deltaTime / 3;
            yield return null;
        }
        musicPlayer.clip = titleScreenMusic;
        yield break;
    }

    private IEnumerator IncreaseVolumeToMax()
    {
        yield return new WaitForSeconds(1f);
        musicPlayer.Play();
        while (musicPlayer.volume < 0.15)
        {
            musicPlayer.volume += Time.deltaTime / 3;
            yield return null;
        }
        yield break;
    }
}
