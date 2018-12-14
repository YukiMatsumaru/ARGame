using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PutterController : MonoBehaviour {

    private GameObject ARCamera;
    private Vector3 plusPosition;
    private Vector3 plusRotation;


    // Use this for initialization
    void Start () {
        ARCamera = GameObject.Find("ARCamera");
        plusPosition = new Vector3(-1.5f, -18.0f, -2.0f);
        plusRotation = new Vector3(-180.0f, 0, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = ARCamera.transform.position + plusPosition;
        gameObject.transform.rotation = Quaternion.Euler(ARCamera.transform.rotation.eulerAngles + plusRotation);
    }
}
