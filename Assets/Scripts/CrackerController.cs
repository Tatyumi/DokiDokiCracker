using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class CrackerController : MonoBehaviour
{
    /// <summary>クラッカーの画像</summary>
    public Image ImageCracker;

    // Use this for initialization
    void Start()
    {
        ImageCracker.fillAmount = Constans.CRACKER_FILLAMOUNT;
    }
}
