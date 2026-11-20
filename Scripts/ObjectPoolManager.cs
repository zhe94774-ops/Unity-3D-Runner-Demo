using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    public GameObject[] prefab;
    public int poolSize = 20; 
    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab[Random.Range(0, prefab.Length)]);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject SpawnObstacle(Vector3 position)
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return null;
        }
    }
    public void ReturnObstacle(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
    
}
