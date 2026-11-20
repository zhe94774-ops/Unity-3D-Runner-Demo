using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private float speed = 2f;
    private int pointNum = 1;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[pointNum].transform.position,speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, points[pointNum].transform.position) < 0.1f)
        {
            pointNum = Mathf.Abs(pointNum - 1);

            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

}
