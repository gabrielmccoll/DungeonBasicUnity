using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            UIManager.Instance.MaxHeartsIncrease();
           

        }
     

    }
}
