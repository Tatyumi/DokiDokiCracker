using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour {

    /// <summary>StartTextの横サイズ</summary>
    private const float START_TEXT_SIZE_X = 700;
    /// <summary>StartTextの縦サイズ</summary>
    private const float START_TEXT_SIZE_Y = 300;

    //子オブジェクトの[StartText]を取得
    private GameObject StartText;

    // Use this for initialization
    void Start () {
        //StartText = transform.Find("StartText").gameObject;
        //RectTransform startTextRect = StartText.transform.GetComponent<RectTransform>();
        //startTextRect.sizeDelta = new Vector2(START_TEXT_SIZE_X, 0);
        //StartText.transform.localScale = new Vector2(START_TEXT_SIZE_X, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //StartText.transform. += new Vector3(0, 0.01f);

    }
}
