using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketManager : MonoBehaviour {

    private string tagName;
    private PlayerManager PM;
    private JudgmentBucket JB;
    private BuketGameStart BGS;

	// Use this for initialization
	void Start () {
        tagName = gameObject.transform.tag;
        PM = GameObject.Find("ObjectManager").GetComponent<PlayerManager>();
        JB = GameObject.Find("JudgmentObject").GetComponent<JudgmentBucket>();
        BGS = GameObject.Find("ObjectManager").GetComponent<BuketGameStart>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick()
    {

        BGS.SetGameStartFlag(true);

        switch(tagName)
        {
            case "twoPlayers":
                PM.SetPlayerNum(2);
                JB.OnClickButton();
                break;
            case "thirdPlayers":
                PM.SetPlayerNum(3);
                JB.OnClickButton();
                break;
            case "fourPlayers":
                PM.SetPlayerNum(4);
                JB.OnClickButton();
                break;
        }
    }

}
