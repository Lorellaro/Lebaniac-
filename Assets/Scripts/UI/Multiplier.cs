using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    TextMeshProUGUI multiplierUI;

    public int scoreMultiplier = 1;

    void Start()
    {
        multiplierUI = GetComponent<TextMeshProUGUI>();
        multiplierUI.SetText(scoreMultiplier.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseMultiplier(int amountToAdd)
    {
        scoreMultiplier += amountToAdd;

        if(scoreMultiplier <= 0)
        {
            scoreMultiplier = 1;
        }
        multiplierUI.SetText(scoreMultiplier.ToString());
    }
}
