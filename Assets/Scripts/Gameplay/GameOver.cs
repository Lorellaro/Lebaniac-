using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;

    string highScore = "0";

    public void PlayeGameOver()
    {
        gameOverUI.SetActive(true);
        SetHighScore();
    }

    private void SetHighScore()
    {
        highScore = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>().text;
        GameObject.FindWithTag("HighScore").GetComponent<Text>().text = highScore;
    }
}
