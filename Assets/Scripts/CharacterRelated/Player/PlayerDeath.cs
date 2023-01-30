using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Vector2 respawnPos;

    Health healthScript;

    int lives = 3;//Must be the same as lives display

    private void Start()
    {
        healthScript = GetComponent<Health>();
    }

    public void ResetPlayer()
    {
        lives--;
        if (lives <= 0) { return; }
        healthScript.dead = false;
        healthScript.healthPoints = healthScript.maxHealthPoints;
        transform.position = respawnPos;

    }
}
