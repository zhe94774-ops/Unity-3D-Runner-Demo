using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject[] trackSegments;
    public Transform player;
    public float trackLength = 230;  //跑道长度
    private int currentIndex = 0;
    private float spawnZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnZ = 0f;
        for (int i = 0; i < trackSegments.Length; i++)
        {
            float originalX = trackSegments[i].transform.position.x;
            float originalY = trackSegments[i].transform.position.y;

            trackSegments[i].transform.position = new Vector3(originalX, originalY, spawnZ);
            spawnZ += trackLength;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trackSegments[currentIndex].transform.position.z < player.position.z -trackLength)
        {
            RecycleSegment(trackSegments[currentIndex]);
            currentIndex = (currentIndex + 1) % trackSegments.Length;
        }
    }
    void RecycleSegment(GameObject segment)
    {
        // 获取原物体的 X 和 Y（不管它们是多少，反正保持一致）
        float safeX = segment.transform.position.x;
        float safeY = segment.transform.position.y;

        // 只改变 Z 轴
        segment.transform.position = new Vector3(safeX, safeY, spawnZ);
        spawnZ += trackLength;

        foreach (Transform child in segment.transform)
        {
            if (!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
