using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketGameButton : MonoBehaviour {

    public GameObject Button;

    private PlayerManager PM;
    private JudgmentBucket JB;

    // Use this for initialization
    void Start () {
        PM = GameObject.Find("ObjectManager").GetComponent<PlayerManager>();
        JB = GameObject.Find("JudgmentObject").GetComponent<JudgmentBucket>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // プレイヤーの順番を変更する処理
    private void ChangePlayers()
    {

        int playerOrder = JB.GetPlayerOrder();

        // プレイヤーの人数と今の順番が一致していたら
        if(PM.GetPlayerNum() <= JB.GetPlayerOrder())
        {
            // 一番始めの人に戻す
            JB.SetPlayerOrder(1);
        }
        else
        {
            // 次の人に進める
            playerOrder++;
            JB.SetPlayerOrder(playerOrder);

        }
    }

    // ボタンを押したら
    public void OnClick()
    {
        switch (gameObject.transform.tag)
        {
            case "NextButton":
                Button.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "YesButton":
                ChangePlayers();
                Button.SetActive(false);
                Time.timeScale = 1f;
                break;
            case "NoButton":
                Button.SetActive(false);
                Time.timeScale = 1f;
                break;
        }

    }

    

}
