using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerHealth playerHealth;
  

    public void NewGame()
    {
        ResetPlayerHealth();
        SceneManager.LoadScene("Level1");
    }

    public void ToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }


    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        ResetPlayerHealth();
    }

    public void ResetPlayerHealth()
    {
        playerHealth.currentHearts = 3;
        playerHealth.maxHearts = 3;
    }
}
