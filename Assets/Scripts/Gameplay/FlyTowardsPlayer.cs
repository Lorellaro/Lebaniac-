using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 50f;

    public bool canMove = true;

    GameObject targetPosition;
    Rigidbody2D rb;
    Vector3 target;
    Vector3 parriedTargetPos;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindWithTag("AimPos");
        rb = GetComponent<Rigidbody2D>();

        if(targetPosition == null) { return; }

        target = (targetPosition.transform.position - transform.position).normalized;// sets direction to ad force in
    }

    public void ResetTarget(GameObject newTargetPos, float addedSpeed)
    {
        //targetPosition = newTargetPos;
        parriedTargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        parriedTargetPos = new Vector3(parriedTargetPos.x, parriedTargetPos.y, 0);
        target = (parriedTargetPos - transform.position).normalized * addedSpeed;// sets direction to ad force in
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!canMove) { //rb.velocity = new Vector2(0, 0); 
            return; }
        //rb.velocity = (target * moveSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + (target * (moveSpeed * Time.deltaTime)));
    }
}
