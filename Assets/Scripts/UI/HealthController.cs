using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    public int playerHealth;
    [SerializeField] SceneController _scenecontroller;
    [SerializeField] private Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }


    public void UpdateHealth()
    {

        if (playerHealth == 0)
        {
            _scenecontroller.GameOver();
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }
}
