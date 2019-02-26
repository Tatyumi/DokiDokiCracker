using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrackerController : MonoBehaviour
{

    /// <summary>クラッカーの画像</summary>
    public Image imageCracker;
    /// <summary>クラッカーの初期FILLOUT値</summary>
    private const float CRACKER_FILLAMOUNT = 0.97f;

    // Use this for initialization
    void Start()
    {
        imageCracker.fillAmount = CRACKER_FILLAMOUNT;

    }
}
