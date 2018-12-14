using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGolfButtonScript : MonoBehaviour
{

    public GameObject Button;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    // ボタンを押したら
    public void OnClick()
    {
        switch(gameObject.transform.tag)
        {
            case "RetryButton":
                Button.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "YesButton":
                SceneManager.LoadScene("MiniGolfGame");
                Time.timeScale = 1f;
                break;
            case "NoButton":
                Button.SetActive(false);
                Time.timeScale = 1f;
                break;
        }

    }

}
