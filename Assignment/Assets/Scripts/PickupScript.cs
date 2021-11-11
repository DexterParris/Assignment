using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioData.Play();
            Helper.HealthSystem(0,4);
            Destroy(gameObject,0.2f);
            
        }
    }

}
