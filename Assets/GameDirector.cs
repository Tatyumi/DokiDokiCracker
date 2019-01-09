using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    private GameObject gameObj;

    // Use this for initialization
    void Start()
    {
        gameObj = GameObject.Find("AudioBox");
        //タイトルのBGMを再生
        gameObj.GetComponent<AudioBox>().StartTitleBgm();
    }

    // Update is called once per frame
    void Update()
    {
        //画面をタップした場合
        if (Input.GetMouseButtonDown(0))
        {
            gameObj.GetComponent<AudioBox>().StopMusic();
            MovePlayscene();
        }
    }
    
    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitleScene()
    {
        SceneManager.LoadScene("titleScene");
    }
    
    /// <summary>
    /// プレイシーンに遷移する
    /// </summary>
    public void MovePlayscene()
    {
        SceneManager.LoadScene("playScene");
    }

}
