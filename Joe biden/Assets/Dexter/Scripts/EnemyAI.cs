using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    public int state = 0;
    public float walktimer = 10;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            idle();
        }
        else if (state == 1)
        {
            moving();
        }
        else if (state == 2)
        {
            attacking();
        }
        else
        {
            state = 0;
        }
    }

    void OnTriggerEnter(Collision col)
    {
        if (col != null)
        {
            if (col.gameObject.tag == "Player")
            {
                state = 1;
            }
        }

        
    }
    void idle()
    {
        transform.Rotate(0, 5, 0 * Time.deltaTime);
    }

    void moving()
    {
        if (walktimer > 0)
        {
            walktimer -= Time.deltaTime;
            rb.AddForce(transform.forward * 20 * Time.deltaTime);
        }
        else
        {
            state = 0;

        }
    }
    void attacking()
    {

    }
}
