using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3,6,true);
        Physics2D.IgnoreLayerCollision(6,6,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
