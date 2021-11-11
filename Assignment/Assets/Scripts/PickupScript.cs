using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Helper.HealthSystem(0,4);
            Destroy(gameObject,0.2f);
            
        }
    }

}
