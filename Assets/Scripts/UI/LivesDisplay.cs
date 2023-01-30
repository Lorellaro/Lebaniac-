using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    TextMeshProUGUI livesUI;

    GameObject player;
    PlayerDeath playerDeathScript;
    [SerializeField] GameOver gameOverScript;

    [SerializeField] int lives = 3;

    void Start()
    {
        livesUI = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player");
        playerDeathScript = player.GetComponent<PlayerDeath>();
        livesUI.SetText(lives.ToString());
    }

    public void AlterLife(int amountToChange)
    {
        lives += amountToChange;
        if(lives <= 0)
        {
            Time.timeScale = 0.2f;
            gameOverScript.PlayeGameOver();
        }
        else
        {
            player.GetComponent<Animator>().SetTrigger("Die");
        }
        livesUI.text = lives.ToString();
    }

}
