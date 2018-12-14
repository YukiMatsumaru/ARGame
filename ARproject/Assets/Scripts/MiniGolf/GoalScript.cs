using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {


    public GameObject effect;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GolfBall")
        {
            Debug.Log("aa");
            effect.SetActive(true);
            Destroy(gameObject);
        }
    }
}
