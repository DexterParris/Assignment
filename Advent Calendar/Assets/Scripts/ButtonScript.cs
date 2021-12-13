using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonsPress()
    {
        int date = Int32.Parse(System.DateTime.Now.ToString("dd"));
        string name = gameObject.name;
        int namenum = Int32.Parse(name);


        if(date >= namenum)
        {
            if(audiosrc != null)
            {
                audiosrc.Play();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            
        }
        

    }
    void OnGUI()
    {
        int date = Int32.Parse(System.DateTime.Now.ToString("dd"));
        string name = gameObject.name;
        int namenum = Int32.Parse(name);

        int remainingint = 25 - date;
        string remaining = remainingint.ToString();
        string content = "there are ";
        string stateText = remaining + " days until christmas";

        if(remainingint > 1) 
        {
            GUILayout.Label($"<color='black'><size=30>{content}\n{stateText}</size></color>");
        }
        else if (remainingint == 1)
        {
            GUILayout.Label($"<color='black'><size=30>{"there is "}\n{"1 day until christmas"}</size></color>");
        }
        else if (remainingint > 25)
        {
            GUILayout.Label($"<color='black'><size=30>{"it has been christmas already!"}</size></color>");
        }
        
    }
}
