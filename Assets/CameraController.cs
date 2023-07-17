using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    

    // Update is called once per frame
    void Update()
    {
        //lower case transform is a shortcut to get comptonent transform for the object it's attached to
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
