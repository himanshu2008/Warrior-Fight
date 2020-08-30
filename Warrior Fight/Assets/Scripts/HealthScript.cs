using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private float x_Death = -90f;
    private float death_Smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;

    void Update()
    {
        if (playerDied)
        {
            rotate_Time
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
        }
    }
}
