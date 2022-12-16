using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fire_Hit"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
            {
                anim.SetBool("Fire", true);
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fire_On"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
            {
                anim.SetBool("Prefire", false);
                anim.SetBool("Fire", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("Prefire", true);
            /*if(anim.GetCurrentAnimatorStateInfo(0).IsName("Fire_On"))
            {
                collision.gameObject.GetComponent<PlayerLife>().Die();
            }*/
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fire_On"))
            {
                collision.gameObject.GetComponent<PlayerLife>().Die();
            }
        }
    }
}
