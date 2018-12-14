using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDelete : MonoBehaviour {

    [Tooltip("パーティクル")]   
    public ParticleSystem myParticleSystem;

    // オブジェクトを消す時間指定
    private const float MAX_TIME = 4;
    
    // タイムカウント用変数
    private float time;

    // Use this for initialization
    void Start () {
        time = 0;
        gameObject.transform.rotation = Quaternion.Euler(-90, 90, 0);
    }
	
	// Update is called once per frame
	void Update () {

        // タイムをカウントする
        time += Time.deltaTime;

        // タイムが指定されたタイム以上になったら
        if (time >= MAX_TIME)
        {
            // このオブジェクトを消す
            Destroy(gameObject);
        }
    }
}
