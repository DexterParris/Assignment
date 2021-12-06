using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    public int state = 0;
    public float walktimer = 3f;
    // Start is called before the first frame update

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

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
            rb.freezeRotation = true;
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

    void OnTriggerEnter(Collider col)
    {
        if (col != null && col.gameObject.tag == "Player")
        {
            state = 1;
        }

        
    }
    void idle()
    {
        transform.Rotate(0, 2, 0 * Time.deltaTime);
    }

    void moving()
    {
        

        if (walktimer > 0)
        {
            walktimer -= Time.deltaTime;
            transform.position += transform.right * Time.deltaTime *2;
        }
        else
        {
            state = 0;
            walktimer = 3f;
        }
    }
    void attacking()
    {

    }
}
