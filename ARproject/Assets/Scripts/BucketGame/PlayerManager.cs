using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private int playerNum;

    // Use this for initialization
    void Start () {
        playerNum = 1;

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SetPlayerNum(int num)
    {
        playerNum = num;
    }

    public int GetPlayerNum()
    {
        return playerNum;
    }

}
