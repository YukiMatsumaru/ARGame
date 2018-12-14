using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    //カメラ（このゲームではARカメラ)
    private new Camera camera;

    private GameObject mainCameraObj;

    // バケツに触れているか
    private bool isJudgment;

    // 位置座標
    private Vector3 position;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    // 触れているかどうか管理用フラグ
    private bool isTouched;

    // スタートボタンスクリプト
    private BuketGameStart BGS;

    // 空き缶のオブジェクト
    private GameObject can;
    public GameObject emptyCanPrefab;

    private GameObject BucketObject;

    [Tooltip("射出する角度")]
    private float ThowingAngle;

    // タイマー
    private float time;
    private const float MAX_TIME = 3;

    void Start()
    {
        // フラグの初期化
        isTouched = false;
        isJudgment = false;

        // カメラの情報を取得
        mainCameraObj = GameObject.Find("ARCamera");
        camera = mainCameraObj.GetComponent<Camera>();
        BGS = GameObject.Find("ObjectManager").GetComponent<BuketGameStart>();

        // バケツオブジェクトの情報取得
        BucketObject = GameObject.Find("bucket");

        // タイマーの初期化
        time = MAX_TIME;

    }
    void Update()
    {
        if (BGS.GetGameStartFlag())
        {
            // タップしたら
            if (Input.GetMouseButton(0) && time >= MAX_TIME)
            {
                // タップした座標にオブジェクトを生成する
                TouchCheck();

                isTouched = true;
                isJudgment = false;
                time = 0;

            }
            else
            {
                isTouched = false;
            }

            // タップしているとき
            if (isTouched)
            {
                // タップしている座標とオブジェクト一致させる
                TouchedPos();

                // オブジェクトの速度、回転角の初期化
                Reset();

            }

        }

        // タイマーの更新
        time += Time.deltaTime;

    }

    void TouchCheck()
    {

        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;

        // Z軸修正
        position.z = 40f;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = camera.ScreenToWorldPoint(position);

        // ワールド座標に変換されたマウス座標を代入
        if (!isTouched) // 触れていたら
        {
            // オブジェクトを生成する
            can = Instantiate(emptyCanPrefab, screenToWorldPointPosition,Quaternion.Euler(camera.transform.eulerAngles),gameObject.transform);

            // オブジェクトの標的座標
            Vector3 targetPosition = BucketObject.transform.position;

            // 射出角度
            float angle = 45.0f;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(can.transform.position, targetPosition, angle);

            // 射出
            Rigidbody rid = can.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }

    }

    void TouchedPos()
    {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;

        // Z軸修正
        position.z = 40f;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = camera.ScreenToWorldPoint(position);

        can.transform.position = screenToWorldPointPosition;

    }

    void Reset()
    {

        Rigidbody rigidbody = this.GetComponent<Rigidbody>();

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        can.transform.rotation = Quaternion.Euler(-90, 0, -180);

        // 慣性テンソル値と回転を初期化する
        rigidbody.ResetInertiaTensor();

    }

    // バケツに命中する射出速度の計算
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = 25.0f;

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }

    // ゲッター
    public bool GetJudgmentFlag()
    {
        return isJudgment;
    }

    // セッター
    public void SetJudgmentFlag(bool flag)
    {
        isJudgment = flag;
    }

    public bool GetIsTouchFlag()
    {
        return isTouched;
    }

   
}



