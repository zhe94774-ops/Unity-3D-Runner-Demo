using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreditsRun());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreditsRun()
    {
        yield return new WaitForSeconds(0.5f);
        creditsScreen.SetActive(true);
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(0);
    }
}
