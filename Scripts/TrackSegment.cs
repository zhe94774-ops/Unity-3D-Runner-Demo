using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnProbability = 0.6f;

    void OnEnable()
    {
        if (ObjectPoolManager.Instance == null) return;
        foreach (Transform point in spawnPoints)
        {
            if (point.childCount > 0)
            {
                continue;
            }
            if (Random.value < spawnProbability)
            {
                GameObject newObstacle = ObjectPoolManager.Instance.SpawnObstacle(point.position);
                if (newObstacle != null)
                {
                    newObstacle.transform.SetParent(point);
                    newObstacle.transform.localPosition = Vector3.zero; // 强制归零，防止偏移
                }
            }
        }
    }
}
