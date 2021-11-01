using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player; //Get the player's position from a gameobject of your choice
    public Vector3 offset; //Offset the camera's position from the player

    void Update()
    {
        transform.position = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, offset.z); // Make the camera follow the player as they move, but not when the rotate
    }
}
