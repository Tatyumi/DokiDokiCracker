using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class empObjectDirector : MonoBehaviour
{
    /// <summary>クラッカーの紐の画像</summary>
    public GameObject objString;
    /// <summary>クラッカーの画像</summary>
    public GameObject objCracker;
    /// <summary>発射クラッカー画像</summary>
    public GameObject objCrackerFire;
    /// <summary>背景の画像</summary>
    public GameObject objBackGround;
    /// <summary>視覚的クラッカーと紐のずれ</summary>
    private const float REGULATE_POS_X = 3.5f;
    /// <summary>紐の横幅</summary>
    private const float STRING_WIDTH = 10.0f;
    /// <summary>ゲームスタートフラグ</summary>
    public static bool isStart = false;

    // Use this for initialization
    void Start()
    {
        isStart = false;

        //背景画像のサイズ
        RectTransform backRect = objBackGround.GetComponent<RectTransform>();
        backRect.sizeDelta = new Vector2(Screen.width, Screen.height);
        
        //紐のサイズ
        RectTransform strRect = objString.GetComponent<RectTransform>();
        strRect.sizeDelta = new Vector2(STRING_WIDTH, Screen.height / 2);

        //クラッカーの初期値位置
        objCracker.transform.position = new Vector2(Screen.width/2, Screen.height/2);

        //発射クラッカーの初期位置
        objCrackerFire.transform.position = objCracker.transform.position;
        
        //紐の初期位置
        objString.transform.position = new Vector2(Screen.width/2, Screen.height / 2);

        SetCracker();
    }
    
    /// <summary>
    /// クラッカーを初期状態にします
    /// </summary>
    public void SetCracker()
    {
        objCracker.SetActive(true);
        objCrackerFire.SetActive(false);
    }

    /// <summary>
    /// クラッカーを発射状態にします
    /// </summary>
    public void FireCracker()
    {
        objCracker.SetActive(false);
        objCrackerFire.SetActive(true);
    }
}
