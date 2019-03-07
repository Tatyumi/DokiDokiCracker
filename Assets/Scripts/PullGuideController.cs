using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullGuideController : MonoBehaviour
{
    /// <summary>点滅秋期</summary>
    public float Interval = 1.0f;
    /// <summary>次動作までの間隔</summary>
    private float nextTime;
    
    void Start()
    {
        nextTime = Time.time;
    }

    void Update()
    {
        //次の動作時間に達した場合
        if (Time.time > nextTime)
        {
            this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
            nextTime += Interval;
        }
    }
}
