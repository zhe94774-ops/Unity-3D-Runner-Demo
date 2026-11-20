using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int coinScore;
    //public int scoreAmount; //分数增加
    public GameObject scoreEffect;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Audiomanager.instance.PlaySfx(1);
            Instantiate(scoreEffect,transform.position,Quaternion.identity);
            coinScore++;
            //coinScore = scoreAmount;
            scoreText.text = "SCORE : " + coinScore;
            other.gameObject.SetActive(false);
        }
    }
}
