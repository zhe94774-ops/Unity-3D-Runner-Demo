using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f; //distance between lanes
    public float sideTranstionSpeed = 15f; //侧向移动的速度
    private int currentLane = 1;//初始从中间车道开始
    private Vector3 targetPosition;
    private float startX;
    public float jumpForce = 7f;
    public float grivaty = 20f;
    private float verticalVelocity;  //垂直速度
    private bool isGrounded = true;
    private float groundY;
    public int currentHealth = 5;
    public int maxHealth = 5;
    public static Player Instance; //单例
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        groundY = transform.position.y;

        //游戏初始显示最大血量
        Healthbar.Instance.SetmaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
            {
                currentLane--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 2)
            {
                currentLane++;
            }
        }
        float targetX = startX + (currentLane - 1) * laneDistance;
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, sideTranstionSpeed * Time.deltaTime);

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Audiomanager.instance.PlaySfx(2);

            verticalVelocity = jumpForce;
            isGrounded = false;
        }
        //应用重力
        if (!isGrounded)
        {
            verticalVelocity -= grivaty * Time.deltaTime;
        }

        Vector3 moveVector = transform.position;
        moveVector.y += verticalVelocity * Time.deltaTime;

        if (moveVector.y <= groundY)
        {
            moveVector.y = groundY;
            verticalVelocity = 0;
            isGrounded = true;
        }
        transform.position = moveVector;
    }

    //负责扣血的方法
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Healthbar.Instance.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    //专门加血的方法
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        } 

        Healthbar.Instance.SetHealth(currentHealth);
    }
}
