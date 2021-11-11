using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioData.Play();
            Helper.HealthSystem(1,0);
            
        }
    }
}

