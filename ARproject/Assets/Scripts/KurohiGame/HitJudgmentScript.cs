using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudgmentScript : MonoBehaviour {
    //剣のプレファブ
    private GameObject Sword;
    //ダメージチェック
    private bool damageCheck;
    //乱数
    private int randomNum;
    //剣が触れた回数
    private int hitNum;

	// Use this for initialization
	void Start () {
        damageCheck = false;
        hitNum = 0;
        randomNum = Random.Range(1, 8);
        Sword = GameObject.Find("Sword(Clone)");
    }

    // Update is called once per frame
    void Update () {

        if (damageCheck)
        {

            hitNum++;
            damageCheck = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "SwordTag")
        {
            damageCheck = true;
        }
    }

    // あたった回数のゲッター
    public int GetHitNum()
    {
        return hitNum;
    }

    // 飛ぶまでの回数のゲッター
    public int GetRandomNum()
    {
        return randomNum;
    }

}
