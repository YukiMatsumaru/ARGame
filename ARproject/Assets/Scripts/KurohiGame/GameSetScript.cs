using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetScript : MonoBehaviour {

    public GameObject prefab;
    private GameObject resetButton;
    private HitJudgmentScript HJS;
    private Animator canAnimation;
    private bool endFlag;
    private Vector3 pos;

    public GameObject[] gameoverObj;



	// Use this for initialization
	void Start () {
        HJS = GameObject.Find("Barrel").GetComponent<HitJudgmentScript>();
        canAnimation = GetComponent<Animator>();
        endFlag = false;
        pos = GameObject.Find("Akicanman").transform.position;

        resetButton = GameObject.Find("ResetButton");
        resetButton.SetActive(false);

        for (int i = 0; i < gameoverObj.Length; i++)
            gameoverObj[i].SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if(HJS==null)
        {
            Debug.Log("中身がありません");
            return;
        }

        if (HJS.GetHitNum() >= HJS.GetRandomNum() && !endFlag)
        {
            Instantiate(prefab, pos, Quaternion.identity,GameObject.Find("ImageTarget_KurohiGame").transform);
            endFlag = true;
            canAnimation.SetBool("Damage Bool", true);
            resetButton.SetActive(true);

            for (int i = 0; i < gameoverObj.Length; i++)
                gameoverObj[i].SetActive(true);

        }


    }

}
