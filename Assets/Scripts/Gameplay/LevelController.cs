using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject Instructions;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetUI(pauseScreen);
            Instructions.SetActive(false);
        }
    }

    public void SetUI(GameObject pauseScreen)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);

        }
        else
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        GetComponent<AudioSource>().Play();
    }
}
