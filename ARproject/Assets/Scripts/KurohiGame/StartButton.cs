using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 黒髭ームのスタートボタンスクリプト
/// </summary>

public class StartButton : MonoBehaviour {

    private GameObject homeButton;
    private bool startFlag;

	// Use this for initialization
	void Start () {
        startFlag = false;
        homeButton = GameObject.Find("HomeButton");
        homeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
     
	}

    public void OnClick()
    {
        gameObject.SetActive(false);
        GameObject.Find("Title").SetActive(false);
        homeButton.SetActive(true);
        startFlag = true;
    }

    public bool GetStartFlag()
    {
        return startFlag;
    }

}
