using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{

    private Transform player;//用于追踪玩家位置
    void Start()
    {
        

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }
    void Update()
    {
        if (player != null && transform.position.z < player.position.z - 20f)
        {
            transform.SetParent(null);

            ObjectPoolManager.Instance.ReturnObstacle(this.gameObject);
        }
        
    }
    
}
