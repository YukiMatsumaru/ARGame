using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeSpanScript : MonoBehaviour
{

    TouchController TC;

	// Use this for initialization
	void Start ()
    {
        TC = GameObject.Find("ObjectManager").GetComponent<TouchController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!TC.GetIsTouchFlag())
        Destroy(gameObject, 30.0f);
	}
}
