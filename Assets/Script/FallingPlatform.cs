using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float restoreTime = 2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private Vector2 originPosition;

    private void Start()
    {
        originPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        anim.SetBool("Fall", true);
        rb.bodyType = RigidbodyType2D.Dynamic;
        //Destroy(gameObject, destroyDelay);
        yield return new WaitForSeconds(restoreTime);
        rb.velocity = Vector2.zero;
        anim.SetBool("Fall", false);
        transform.position = originPosition;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
