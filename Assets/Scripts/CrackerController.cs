using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonConstans;

public class CrackerController : MonoBehaviour
{
    /// <summary>クラッカーの画像</summary>
    public Image ImageCracker;
    
    void Start()
    {
        ImageCracker.fillAmount = Value.CRACKER_FILLAMOUNT;
    }
}
