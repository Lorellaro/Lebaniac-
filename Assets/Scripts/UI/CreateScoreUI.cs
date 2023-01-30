using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateScoreUI : MonoBehaviour
{
    [SerializeField] GameObject textComponent;

    public void SpawnText(int number, int scoreMultiplier, Transform objTransform)//Creates and adds the score text
    {
        textComponent.GetComponent<TextMeshProUGUI>().text = number.ToString() + "\n X" + scoreMultiplier;
        Instantiate(textComponent, transform.position, transform.rotation, transform);
    }
}
