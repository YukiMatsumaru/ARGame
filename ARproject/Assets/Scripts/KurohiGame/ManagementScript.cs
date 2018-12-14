using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementScript : MonoBehaviour {

    bool crickButtonFlag;


    // Use this for initialization
    void Start()
    {
        crickButtonFlag = true;

    }

    // Update is called once per frame
    void Update()
    {

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
