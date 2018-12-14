using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    // ボタンオブジェクト
    public GameObject button;

    // ソードのPrefab
    public GameObject swordPrefab;

    public GameObject smokePrefab;

    // フラグ管理用
    private ManagementScript MS;

    // ボタン機能の制御用
    private HitJudgmentScript HJS;

    private StartButton SB;

    // 親となるボタンの初期座標用
    private Vector3 parentPosition;

    // 移動量
    float MoveArrow;

    // Use this for initialization
    void Start () {

        HJS = GameObject.Find("Barrel").GetComponent<HitJudgmentScript>();

        MS = GameObject.Find("ManagementButtonFlag").GetComponent<ManagementScript>();

        SB = GameObject.Find("StartButton").GetComponent<StartButton>();

        MoveArrow = 0;

        // ボタンの初期座標を代入
        parentPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MoveArrow += 0.1f;

        // 一定のリズムで移動させる
        gameObject.transform.position += gameObject.transform.right * Mathf.Sin(MoveArrow)/* * Time.deltaTime*/;

    }

    // ボタンを押したら
    public void OnClick()
    {
        // ボタンがクリックできる状態ではずれを引いていないときかつゲームがスタートしてるとき
        if (MS.GetCrickButtonFlag() == true && 
            HJS.GetHitNum() < HJS.GetRandomNum()&&
            SB.GetStartFlag())
        {
            // ボタン非表示
            button.SetActive(false);

            // Prefabの生成
            // ソード
            Instantiate(swordPrefab,
                parentPosition,
                Quaternion.Euler(
                    gameObject.transform.rotation.eulerAngles.x - 90.0f,
                    gameObject.transform.rotation.eulerAngles.y + 90.0f
                    , gameObject.transform.rotation.eulerAngles.z
                    ),GameObject.Find("ImageTarget_KurohiGame").transform);

            // スモーク
            Instantiate(smokePrefab,
                parentPosition,
                Quaternion.Euler(
                    gameObject.transform.rotation.eulerAngles.x - 90.0f,
                    gameObject.transform.rotation.eulerAngles.y + 90.0f
                    , gameObject.transform.rotation.eulerAngles.z
                    ),GameObject.Find("ImageTarget_KurohiGame").transform);

            // クリックできないようにする
            MS.SetCrickButtonFlag(false);

        }
        
    }

}
