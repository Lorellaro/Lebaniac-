using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTotal : MonoBehaviour
{
    [SerializeField] GameObject multiplierValue;

    TextMeshProUGUI scoreUI;

    Multiplier multiplier;
    CreateScoreUI textSpawnUIScript;

    int score = 0;

    //Increase multiplier when:
        /*
            player hits enemy,
        */
    
    //Decrease multiplier when:
        /*
            playerDies = set to 1x
            playerisHit      
        */

    void Start()
    {
        scoreUI = GetComponent<TextMeshProUGUI>();
        scoreUI.SetText(score.ToString());
        multiplier = multiplierValue.GetComponent<Multiplier>();
        textSpawnUIScript = GameObject.FindWithTag("pointSpawner").GetComponent<CreateScoreUI>();
    }

    public void AddScore(int points, Transform objTransform)
    {
        if(GameObject.FindGameObjectsWithTag("shortScoreText").Length > 0)
        {
            GameObject textOnScreen = GameObject.FindWithTag("shortScoreText");
            string currentText = textOnScreen.GetComponent<TextMeshProUGUI>().text;
            int.TryParse(currentText, out int textAsNum);//convert string to int
            textOnScreen.GetComponent<TextMeshProUGUI>().SetText((points * multiplier.scoreMultiplier + textAsNum).ToString() + "\n X" + multiplier.scoreMultiplier);
            textOnScreen.GetComponent<Animator>().SetTrigger("Reset");
            //textSpawnUIScript.SpawnText(points * multiplier.scoreMultiplier + textAsNum, objTransform);//no
        }
        else
        {
            textSpawnUIScript.SpawnText(points * multiplier.scoreMultiplier, multiplier.scoreMultiplier, objTransform);
        }

        score += Mathf.RoundToInt(points * multiplier.scoreMultiplier);
        scoreUI.text = score.ToString();
    }


}
