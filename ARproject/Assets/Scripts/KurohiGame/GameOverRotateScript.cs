using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverRotateScript : MonoBehaviour {

    private GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("ARCamera");
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 rotate = Vector3.zero;
        rotate.x = camera.transform.localEulerAngles.x;
        rotate.y = 90.0f;

        gameObject.transform.rotation = Quaternion.Euler(rotate);
		
	}
}
