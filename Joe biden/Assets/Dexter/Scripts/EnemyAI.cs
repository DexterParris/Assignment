using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum Enemystates
    {
        Idle,
        Walk,
        Jump,
        Attack
    }

    private Rigidbody rb;
    private Animator animator;
    Enemystates state = Enemystates.Idle;
    public float walktimer = 3f;
    public int jumpcheck;
    // Start is called before the first frame update

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Start()
    {
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case Enemystates.Idle:
                idle();
                break;

            case Enemystates.Walk:
                moving();
                rb.freezeRotation = true;
                break;

            case Enemystates.Jump:
                jumping();
                break;

            case Enemystates.Attack:
                attacking();
                break;

            default:
                state = Enemystates.Idle;
                break;
        }



    }

    void OnTriggerEnter(Collider col)
    {
        if (col != null && col.gameObject.tag == "Player")
        {
            state = Enemystates.Walk;
        }

        
    }
    void idle()
    {
        if (jumpcheck > 5)
        {
            state = Enemystates.Jump;
        }
        else
        {
            animator.Play("Enemy_Idle");
            transform.Rotate(0, 2, 0 * Time.deltaTime);
        }
        
    }

    void moving()
    {
        animator.Play("Enemy_Walk");
        if (walktimer > 0)
        {
            walktimer -= Time.deltaTime;
            transform.position += transform.right * Time.deltaTime *2;
        }
        else
        {
            
            state = Enemystates.Idle;
            walktimer = 3f;
        }
    }

    void jumping()
    {
        rb.AddForce(transform.up * 600* Time.deltaTime);
        state = Enemystates.Idle;
    }

    void attacking()
    {
        animator.Play("Enemy_Attack");
    }

    void OnGUI()
    {
        string content = walktimer.ToString();
        string stateText = state.ToString();
        GUILayout.Label($"<color='black'><size=40>State= {stateText}\n{content}</size></color>");
    }
}
