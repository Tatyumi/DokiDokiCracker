using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullGuide : MonoBehaviour
{
    /// <summary>次動作までの間隔</summary>
    private float nextTime;
    /// <summary>点滅秋期</summary>
    public float interval = 1.0f;

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //次の動作時間に達した場合
        if (Time.time > nextTime)
        {
            this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
            nextTime += interval;
        }
    }
}
