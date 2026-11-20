using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] trackPrefabs; 
    public Transform player;          
    public float trackLength = 40f;   
    public int initialTrackCount = 4; 

    private List<GameObject> activeTracks = new List<GameObject>();
    private float spawnZ = 0f;

    void Start()
    {
        for (int i = 0; i < initialTrackCount; i++)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        for (int i = 0; i < activeTracks.Count; i++)
        {
            if (activeTracks[i].transform.position.z < player.position.z - trackLength)
            {
                RecycleTrack(activeTracks[i]);
            }
        }
    }

    void SpawnTrack()
    {
        int randomIndex = Random.Range(0, trackPrefabs.Length);
        GameObject newTrack = Instantiate(trackPrefabs[randomIndex], transform);
        newTrack.transform.position = new Vector3(0, 0, spawnZ);

        newTrack.transform.position = new Vector3(0, 0, spawnZ);
        activeTracks.Add(newTrack);

        spawnZ += trackLength;
    }

    void RecycleTrack(GameObject track)
    {

        track.transform.position = new Vector3(0, 0, spawnZ);
        spawnZ += trackLength;

        track.SetActive(false);
        track.SetActive(true);

        
    }
}