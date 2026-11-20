using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring_2 : MonoBehaviour
{
    public int coinScore;
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
            Audiomanager.instance.PlaySfx(2);
            coinScore++;
            //coinScore = scoreAmount;
            scoreText.text = "SCORE : " + coinScore;
            other.gameObject.SetActive(false);
        }
    }
}
