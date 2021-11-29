using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KO : MonoBehaviour
{
    ParticleSystem system1;
    AudioSource bonk;
    // Start is called before the first frame update
    void Start()
    {
        bonk = GetComponent<AudioSource>();
        system1 = GetComponentInChildren<ParticleSystem>();
        if(system1.isPlaying)system1.Stop();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {

        if (other != null)
        {
            if (other.gameObject.tag == "Player")
            {
                bonk.Play();
                if(system1.isStopped) system1.Play();
            }
        }

    }
}
