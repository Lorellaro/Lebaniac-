using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] AudioClip hitWallSFX;
    Animator anim;
    FlyTowardsPlayer flyTowardsPlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flyTowardsPlayerScript = GetComponent<FlyTowardsPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Mage" || collision.tag == "Face")
        {
            anim.SetTrigger("Hit");
            flyTowardsPlayerScript.canMove = false;
        }

        else if (collision.gameObject.tag == "Foreground")
        {
            flyTowardsPlayerScript.canMove = false;
            anim.SetTrigger("Hit");
            AudioSource.PlayClipAtPoint(hitWallSFX, transform.position);
        }
    }

    public void destroyObj()
    {
        Destroy(gameObject);
    }

    public void DisableCollider()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

}
