using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour
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
            Helper.PlayerHealth = 0;
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);

        }
    }
}
