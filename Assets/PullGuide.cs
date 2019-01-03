using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullGuide : MonoBehaviour
{

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
        if (Time.time > nextTime)
        {
            this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
            nextTime += interval;
        }
    }
}
