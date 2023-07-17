using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1toLevel2 : MonoBehaviour
{
    [SerializeField] SceneController _sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

        }
                Debug.Log("load2");
                _sceneController.ToLevel2();
        
    }
}
