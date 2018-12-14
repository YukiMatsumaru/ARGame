using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private float moveForward;
    public GameObject explosionObj;


    // Use this for initialization
    void Start()
    {
        moveForward = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveForward += 0.5f;
        gameObject.transform.position += gameObject.transform.forward * moveForward;
        Destroy(gameObject, 3.0f);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyObject")
        {
            var point = collision.contacts[0];

            Vector3 hitPoint = point.point;

            Instantiate(explosionObj, hitPoint, Quaternion.Euler(0, 0, 0), GameObject.Find("ImageTarget").transform);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
