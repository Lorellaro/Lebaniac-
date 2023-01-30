using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicToComabt : MonoBehaviour
{
    [SerializeField] AudioClip combatMusic;

    GameObject musicPlayerOBJ;
    AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayerOBJ = GameObject.FindWithTag("musicPlayer");
        musicPlayer = musicPlayerOBJ.GetComponent<AudioSource>();
        PlayCombatMusic();
    }

    public void PlayCombatMusic()
    {
        StartCoroutine(WaitTillSilent());
        StartCoroutine(IncreaseVolumeToMax());
    }

    private IEnumerator WaitTillSilent()
    {
        while(musicPlayer.volume > 0)
        {
            musicPlayer.volume -= Time.deltaTime / 3;
            yield return null;
        }
        musicPlayer.clip = combatMusic;
        yield break;
    }

    private IEnumerator IncreaseVolumeToMax()
    {
        yield return new WaitForSeconds(1.5f);
        musicPlayer.Play();
        while (musicPlayer.volume < 0.45)
        {
            musicPlayer.volume += Time.deltaTime / 3;
            yield return null;
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
