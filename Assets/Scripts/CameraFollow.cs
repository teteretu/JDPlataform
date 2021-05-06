using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Start()
    {

    }

    void LateUpdate()
    {
        // current camera position
        Vector3 temp = transform.position;

        if (player != null)
        {
            // set camera x position to player x position
            temp.x = player.transform.position.x;
            transform.position = temp;
        }


    }
}
