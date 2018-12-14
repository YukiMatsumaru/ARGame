using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    private float time;

    public GameObject BulletPrefab;

    // 位置座標
    private Vector3 position;

    //カメラ（このゲームではARカメラ)
    private new Camera camera;

    private GameObject mainCameraObj;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    // Use this for initialization
    void Start () {
        time = 10;

        // カメラの情報を取得
        mainCameraObj = GameObject.Find("ARCamera");
        camera = mainCameraObj.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && time >= 0.3f)
        {
            time = 0;
            // Vector3でマウス位置座標を取得する
            position = Input.mousePosition;

            // Z軸修正
            position.z = 40f;

            // マウス位置座標をスクリーン座標からワールド座標に変換する
            screenToWorldPointPosition = camera.ScreenToWorldPoint(position);

            // オブジェクトを生成する
            Instantiate(BulletPrefab, screenToWorldPointPosition, Quaternion.Euler(camera.transform.eulerAngles.x, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z));

        }
        else
        {
            time += Time.deltaTime;
        }


        

    }
}
