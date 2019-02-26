using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //背景画像のサイズ
        RectTransform backRect = transform.GetComponent<RectTransform>();
        backRect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
