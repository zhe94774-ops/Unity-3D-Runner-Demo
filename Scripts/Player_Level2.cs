using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Level2 : MonoBehaviour
{
    [SerializeField] private int forwardSpeed = 5;
    private int currentLane = 1;
    private int laneDistance = 3;
    private int sideTranstionSpeed = 15;

    private float startX;
    private float groundY;

    [SerializeField] private float jumpForce = 12;
    [SerializeField] private float gravity = 25;
    [SerializeField] private float fallMultiplier = 1.5f; //下落乘数
    private bool isGround = true;
    private float verticalVelocity;
    public float currentBoold = 5;
    public float maxBoold = 5;
    public float damage = 1;

    void Start()
    {
        startX = transform.position.x;
        groundY = transform.position.y;
        BooldBar.Instance.SetMaxBoold(maxBoold);
    }
    
    void Update()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0) currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 2) currentLane++;
        }

        float targetX = startX + (currentLane - 1) * laneDistance;
        float newX = Mathf.Lerp(transform.position.x, targetX, sideTranstionSpeed * Time.deltaTime);

        // Y 轴  跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            verticalVelocity = jumpForce;
            isGround = false;
        }
        if (!isGround)
        {
            if (verticalVelocity > 0)
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            else
            {
                verticalVelocity -= gravity * fallMultiplier * Time.deltaTime;
            }
        }
        float newY = transform.position.y + verticalVelocity * Time.deltaTime;

        if (newY <= groundY)
        {
            newY = groundY;
            isGround = true;
            verticalVelocity = 0;
        }

        transform.position = new Vector3(newX, newY, transform.position.z);//重新赋值！！！
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Audiomanager.instance.PlaySfx(1);
            currentBoold -= damage;
            BooldBar.Instance.SetBoold(currentBoold);  //立即更新UI画面

            if (currentBoold <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            }

        }
    }

}
