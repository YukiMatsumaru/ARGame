using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuketGameStart : MonoBehaviour
{
    //[Tooltip("指定されたタイミングで消すオブジェクト")]
    //public GameObject[] deleteObject;

    //// ボタンのサイズ（変更用）
    //private Vector3 Scale;

    //// ボタンを動かす用のカウンタ
    //private float MoveVariable;

    private bool gameStartFlag;

	// Use this for initialization
	void Start ()
    {
        gameStartFlag = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    //public void OnClick()
    //{
    //    // 指定されたオブジェクト非表示に
    //    for(int i=0;i< deleteObject.Length;i++)
    //    {
    //        deleteObject[i].SetActive(false);
    //    }
    //    gameStartFlag = true;
    //}


    public bool GetGameStartFlag()
    {
        return gameStartFlag;
    }

    public void SetGameStartFlag(bool flag)
    {
        gameStartFlag = flag;
    }
}
