using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float resetTime = 5f;
    [SerializeField] private float jumpForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
            gameObject.SetActive(false);
            Invoke("Respawn", resetTime);
        }
    }
    private void Respawn()
    {
        gameObject.SetActive(true);
    }
}
