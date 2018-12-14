using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    Vector3 movePos;
    float speed;

    float rotate;

    private Vector3 oldPosition; // baba_s 前回の位置
    public float moveDelta; // baba_s 移動量

    // Use this for initialization
    void Start () {
        movePos = Vector3.zero;
        speed = 0;
        rotate = 90.0f;
	}

    // Update is called once per frame
    void Update()
    {
        // baba_s
        oldPosition = transform.position;

        Move();
        //Rotate();

        // baba_s
        moveDelta = (transform.position - oldPosition).magnitude; // マグニチュード（強さ）
        //moveDelta = (transform.position - oldPosition).sqrMagnitude;
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            movePos.x = 0.1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            movePos.x = -0.1f;
        else
            movePos.x = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            movePos.z = 0.1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            movePos.z = -0.1f;
        else
            movePos.z = 0;


        if (Input.GetKey(KeyCode.RightShift)|| Input.GetKey(KeyCode.LeftShift))
            speed = 3;
        else
            speed = 1;

        gameObject.transform.position = gameObject.transform.position + (movePos * speed);

    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.W))
            rotate += 0.1f;
        else if (Input.GetKey(KeyCode.S))
            rotate -= 0.1f;
   
        gameObject.transform.rotation = Quaternion.Euler(90.0f,-180.0f, rotate);
    }


    public float GetMoveDelta()
    {
        return moveDelta;
    }

}
