using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    // 開始位置代入用
    private Vector3 startPos;

    public float power = 1;

    private void Start()
    {
        // 開始位置を代入
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        
        // タグがPutterのものに当たった時
        if (collision.gameObject.tag == "Putter")
        {
            // 現状：Putter オブジェクトの位置から計算している
            // 理想：Putter オブジェクトと当たった位置から計算
            var controller = collision.gameObject.GetComponentInParent<DebugController>();
            var point = collision.contacts[0];

            //Vector3 force = (collision.transform.position - transform.position).normalized * controller.moveDelta * power;
            Vector3 force = (point.point - transform.position).normalized * controller.GetMoveDelta() * power;
            force.y = 0;
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        }

    }

  
}
