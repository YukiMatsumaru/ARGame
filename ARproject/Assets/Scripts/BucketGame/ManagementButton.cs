using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementButton : MonoBehaviour {

    bool crickButtonFlag;

    private GameObject playerSelectButton;
    private GameObject AdachiObject;
    public GameObject NextButton;
    
    // Use this for initialization
    void Start () {
        crickButtonFlag = true;

        playerSelectButton = GameObject.Find("PlayerSelectButton");
        playerSelectButton.SetActive(true);

        AdachiObject = GameObject.Find("Adachi");
        AdachiObject.SetActive(true);

        NextButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnClick()
    {
        playerSelectButton.SetActive(false);
        AdachiObject.SetActive(false);
        NextButton.SetActive(true);
    }
    
    // フラグのゲッター
    public bool GetCrickButtonFlag()
    {
        return crickButtonFlag;
    }

    // フラグのセッター
    public void SetCrickButtonFlag(bool flag)
    {
        crickButtonFlag = flag;
    }
}
