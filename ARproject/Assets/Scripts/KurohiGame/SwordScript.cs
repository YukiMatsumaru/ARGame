using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    // フラグ管理用
    ManagementScript MS;
    public GameObject stabEffect;

    // 移動状態
    private bool moveFlag;

    // 移動値
    public float moveForward;

    // エフェクトを出す座標の代入用
    private Vector3 effectPos;


    // 移動限界値
    private const float MOVE_MAX = 3.7f;

    private bool stopSwordFlag;

    // Use this for initialization
    void Start () {
        // 移動不可状態
        moveFlag = false;
        moveForward = 0;
        stopSwordFlag = false;
        effectPos = Vector3.zero;
        MS = GameObject.Find("ManagementButtonFlag").GetComponent<ManagementScript>();
    }

    // Update is called once per frame
    void Update()
    {

        // 移動可能状態だった場合
        if (moveFlag)
        {

            // 位置が指定された数値以下だった場合
            if (moveForward < MOVE_MAX)
            {
                moveForward += 0.1f;
                // 移動させる
                gameObject.transform.position += gameObject.transform.forward * moveForward/* * Time.deltaTime*/;
            }
            else
            {
                moveForward = MOVE_MAX;
            }
        }

        // ソードの位置が指定された数値を超えたら
        if (moveForward == MOVE_MAX && !stopSwordFlag)
        {
            MS.SetCrickButtonFlag(true);
            stopSwordFlag = true;
            Instantiate(stabEffect, gameObject.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);
        }
    }

    // このオブジェクトがクリックされたら
    public void OnClick()
    {
        // 移動可能にする
        moveFlag = true;

        effectPos = gameObject.transform.position;
    }

}
