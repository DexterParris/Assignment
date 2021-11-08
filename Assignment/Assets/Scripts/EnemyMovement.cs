using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    public float playerpos;
    public float enemypos;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add this in update()
        // this sets the variable to 10
        // From our condition we set up above we said that if "speed">5 then set the animation to "player_Walk"
        DoMove();
    }

    void DoMove()
    {

        playerpos = GameObject.FindWithTag("Player").transform.position.x;
        enemypos = transform.position.x;

        float distance = enemypos - playerpos;

        // stop player sliding when not pressing left or right
        Helper.SetVelocity(gameObject, 0, rb.velocity.y);
        anim.SetBool("Walk", false);
        // check for moving left
        if (distance <10 && distance >1.5f)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            Helper.FlipSprite(gameObject, true);
            Helper.SetVelocity(gameObject, -3, 0);
            distance = enemypos - playerpos;
        }

        // check for moving right
        if (distance >-10 && distance <-1.5f) 
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            Helper.FlipSprite(gameObject, false);
            Helper.SetVelocity(gameObject, 3, 0);
            distance = enemypos - playerpos;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject, 0.1f);
        }
    }

}