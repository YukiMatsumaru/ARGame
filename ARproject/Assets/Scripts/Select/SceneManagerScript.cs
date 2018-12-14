using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    private string tagName;
	// Use this for initialization
	void Start () {
        tagName = gameObject.transform.tag;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        switch(tagName)
        {
            case "Pop-UpEmptyCan":
                SceneManager.LoadScene("Kurohigame");
                break;
            case "BucketGame":
                SceneManager.LoadScene("BucketGame");
                break;
            case "MiniGolfGame":
                SceneManager.LoadScene("MiniGolfGame");
                break;
            case "HomeButton":
                 SceneManager.LoadScene("SelectScene");
                break;
        }
    }
}
