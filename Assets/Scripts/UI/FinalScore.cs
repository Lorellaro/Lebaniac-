using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    string score;
    int scoreInt;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("HighScore").GetComponent<Text>().text;
        GetComponent<TextMeshProUGUI>().text = score;
    }

    public void IsHighScoreEnough() //Checks if high score is better than "Death"s
    {
        int.TryParse(score, out scoreInt);
        if (scoreInt >= 500000)//score is greater than death's score
        {
            SceneManager.LoadScene("Success");
        }
        else
        {
            SceneManager.LoadScene("Failure");
        }
    }

}
