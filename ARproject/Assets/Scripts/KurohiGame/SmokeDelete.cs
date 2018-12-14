using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDelete : MonoBehaviour {

    private float time;

    private const float MAX_TIME = 3;

	// Use this for initialization
	void Start () {
        time = 0;
	}

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= MAX_TIME)
        {
            Destroy(gameObject);
        }
    }
}
