using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private Animator anim;
    [SerializeField] private float distance;
    private bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.name == "Player")
                {
                    rb.gravityScale = 1;
                    isFalling = true;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isFalling", true);
        Invoke("resetAnim", 1);
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().Die();
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }
    private void resetAnim()
    {
        anim.SetBool("isFalling", false);
    }
}
