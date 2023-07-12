using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int spikeDamage;
    [SerializeField] HealthController _healthcontroller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }



    void Damage()
    {
        _healthcontroller.playerHealth = _healthcontroller.playerHealth - spikeDamage;
        _healthcontroller.UpdateHealth();
    }

}

