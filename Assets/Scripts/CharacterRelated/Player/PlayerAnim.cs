using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Blink blinkScript;
    Health healthScript;
    PlayerController playerController;

    Vector2 posDif;
    Vector2 mousePos;
    Vector2 inputSpeed;

    bool isRunning = false;
    bool startTriggers = true;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        blinkScript = GetComponent<Blink>();
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.dead) { return; }

        if (blinkScript.isBlinking) { return; }

        if(!playerController.canRun) { return; }

        CheckIfIsRunning();
        StartCoroutine(SetAnimAfterPause());
    }

    IEnumerator SetAnimAfterPause()
    {
        lookAtMouse();
        yield return new WaitForSeconds(0.1f);
    }

    private void lookAtMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posDif = mousePos - rb.position;

        if(posDif.y > 1)
        {
            if (isRunning)
            {
                animator.SetTrigger("runBack");
            }
            else
            {
                animator.SetTrigger("backIdle");
            }

        }

        if(posDif.y >= -0.5 && posDif.y <= 1)
        {
            flipX();
            if (isRunning)
            {
                animator.SetTrigger("runSide");
            }
            else
            {
                animator.SetTrigger("sideIdle");
            }

        }

        if(posDif.y < -0.5)
        {
            if (isRunning)
            {
                animator.SetTrigger("runForward");
            }
            else
            {
                animator.SetTrigger("frontIdle");
            }
        }
    }

    private void flipX()
    {
        if (posDif.x > 0)// Flips sprite horizontally based on mousePos
        {
            spriteRenderer.flipX = false;
        }
        if (posDif.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void CheckIfIsRunning()
    {
        inputSpeed = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
        if (inputSpeed == new Vector2(0, 0))
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }
}
