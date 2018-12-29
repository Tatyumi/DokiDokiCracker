using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffect : MonoBehaviour {

    //エンドエフェクトの回転速度
    private const float ROLLING_SPEED = 2.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0,ROLLING_SPEED);	
	}
}
