using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinrotation : MonoBehaviour
{
    public float rotateSpeed = 100f;
    
    void Update()
    {
        transform.Rotate(0f,rotateSpeed * Time.deltaTime,0f );
    }
}
