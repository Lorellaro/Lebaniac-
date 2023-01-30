using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    SetMusicToComabt setMusicToComabtScript;

    private void Start()
    {
        //setMusicToComabtScript = GameObject.FindWithTag("MusicSwapper").GetComponent<SetMusicToComabt>();
    }


    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
        GetComponent<AudioSource>().Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
        GetComponent<AudioSource>().Play();
        
    }

    public void QuitGame()
    {
        Application.Quit();
        GetComponent<AudioSource>().Play();
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 4);
        GetComponent<AudioSource>().Play();
    }

}
