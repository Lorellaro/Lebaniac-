using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float attackAdvanceSpeed = 2f;
    [SerializeField] Transform rotator;

    Rigidbody2D rb;
    Animator animator;
    Vector2 inputSpeed;
    Blink blinkScript;
    Health healthScript;

    public bool canRun = true;
    bool stopAttacking = false;

    float defaultRbDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultRbDrag = rb.drag;
        blinkScript = GetComponent<Blink>();
        healthScript = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthScript.dead) { return; }
        if (!canRun)
        {
            if (!stopAttacking)
            {
                rb.drag = 30f;
                return;
            } //Makes Player Stop when blinking.
            else
            {
                rb.drag = 1.5f; return;//Makes player slow when attacking
            }
        }
        Run();
    }

    private void Update()
    {
        if (healthScript.dead) { return; }
        if (blinkScript.isBlinking) { return; }
        Attack();
    }

    private void Run()
    {
        inputSpeed = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity += inputSpeed * moveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(stopAttacking)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((mousePos - rb.position).y > 0)
            {
                animator.SetTrigger("AttackBack");
            }
            else
            {
                animator.SetTrigger("Attack");
            }

            //AttackAdvance();
        }

        if(Input.GetKeyUp(KeyCode.Mouse0) && !blinkScript.isBlinking)//Use this to put player attack anims in
        {
            canRun = false;
            stopAttacking = true;
            spriteRenderer.flipX = true;
        }
    }

    public void CanMove()
    {
        rb.drag = defaultRbDrag;
        canRun = true;
        stopAttacking = false;
    }

    public void CannotMove()
    {
        canRun = false;
        stopAttacking = true;
    }

    private void AttackAdvance()
    {
        //rb.MovePosition(rb.transform.position + rotator.up * attackAdvanceSpeed * Time.deltaTime); // Moves player slightly towards mousePos
    }
}
