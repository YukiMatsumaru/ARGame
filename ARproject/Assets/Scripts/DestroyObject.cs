using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {


    private float destroyTime;
	// Use this for initialization
	void Start () {
		switch(gameObject.transform.tag)
        {
            case "Explosion":
                destroyTime = 1.0f;
                break;
        }


	}
	
	// Update is called once per frame
	void Update () {
       Destroy(gameObject, destroyTime);
	}
}
