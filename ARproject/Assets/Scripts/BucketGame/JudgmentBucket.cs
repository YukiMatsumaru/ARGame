using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgmentBucket : MonoBehaviour {

    [Tooltip("エフェクトのプレハブ")]
    public GameObject effectPrefab;

    [Tooltip("タッチ用スクリプト")]
    public TouchController TC;

    // 現在のバケツに入っている個数
    private int inCount;

    // バケツの中に入るカンの最大数
    private int maxInCount;

    // プレイヤーの順番
    private int number;

    // プレイヤーの人数を取得してくる変数
    private int pNum;

    // ゲーム終了フラグ
    private bool gameSetFlag;

    // ゲームオーバーオブジェクト
    private GameObject gameoverObj;

    // プレイヤーの順番表示用テキスト
    private Text targetText;

    // プレイヤーマネージャー
    private PlayerManager PM;

    // オブジェクト削除用変数
    public GameObject[] deleteObject;

    // Use this for initialization
    void Start () {
        inCount = 0;
        maxInCount = 0;
        gameSetFlag = false;
      
        gameoverObj = GameObject.Find("GameOvers");
        gameoverObj.SetActive(false);

        targetText = GameObject.Find("playerText").GetComponent<Text>();
        targetText.text = "";

        PM = GameObject.Find("ObjectManager").GetComponent<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {
        maxInCount = Random.Range(10,30);

        if (PM.GetPlayerNum() >= 2) 
        targetText.text = "turn of " + "player" + pNum.ToString();

        // バケツに入った個数がMAXになったら
        if (inCount >= maxInCount)
        {
            gameoverObj.SetActive(true);

            for (int i = 0; i < deleteObject.Length; i++)
                deleteObject[i].SetActive(false);

        }

    }

    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {
        // バケツの底に当たりフラグがfalseの時
        if (collision.gameObject.tag == "emptyCan" && !TC.GetJudgmentFlag())
        {
            // プレハブの生成
            Instantiate(effectPrefab, gameObject.transform.position, Quaternion.identity);

            // バケツに入っているので回数を増やす
            inCount++;

            // バケツに当たってる
            TC.SetJudgmentFlag(true);

            // ゲームオブジェクトを削除する
            Destroy(collision.gameObject);

        }
    }

    // ボタンを押した時の処理
    public void OnClickButton()
    {
        number = PM.GetPlayerNum();
        pNum = Random.Range(1, number + 1);
    }

    // プレイヤーの順番を設定する処理
    public void SetPlayerOrder(int orderNum)
    {
        pNum = orderNum;
    }

    // プレイヤーの順番を取得してくる処理
    public int GetPlayerOrder()
    {
        return pNum;
    }

}
