using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject prefab;
 
    // Start is called before the first frame update
    void Start()
    {
        Helper.PlayerHealth = 3;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        DoShoot();
        DoHealthCheck();
    }

    void DoJump()
    { 
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float yvelocity = rb.velocity.y;
        float xvelocity = rb.velocity.x;

        Helper.DoRayCollisionCheck(gameObject, xpos, ypos);
       

        // check for jump
        if (Input.GetKeyDown("space"))
        {
            if(Helper.IsGrounded == true)
            {
                Helper.SetVelocity(gameObject, 0, 7);
            }
        }
    }

    void DoMove()
    {
        float yvelocity = rb.velocity.y;
        // stop player sliding when not pressing left or right
        anim.SetBool("Walk", false);
        Helper.SetVelocity(gameObject, 0, yvelocity);
        // check for moving left
        if (Input.GetKey("a"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            Helper.FlipSprite(gameObject, true);
            Helper.SetVelocity(gameObject, -4, 0);
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            Helper.FlipSprite(gameObject, false);    //flip sprite left
            Helper.SetVelocity(gameObject, 4, 0);
        }

    }


    void DoShoot()
    {

        if (Input.GetKeyDown("s"))
        {
            float xpos = transform.position.x;
            float ypos = transform.position.y;
            float xvel = 7;
            float yvel = 0;

            Helper.MakeBullet(prefab, xpos , ypos + 1.3f, xvel, yvel, anim.GetBool("left")); //instantiate the object using the instantiation method in the helper.cs script

        }
    }

    void DoHealthCheck()
    {
        if(Helper.PlayerHealth == 0)
        {
            Debug.Log("Dead");
        }
    }

}
