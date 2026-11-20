using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private int damageAmount = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            // 获取玩家身上的 PlayerHealth 脚本
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
            
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
