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
        gameObj.GetComponent<AudioBox>().TitleBgmSart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObj.GetComponent<AudioBox>().audioStop();
            movePlayscene();
        }
    }

    //タイトルシーンに遷移する
    public void moveTitleScene()
    {
        SceneManager.LoadScene("titleScene");
    }

    //プレイシーンに遷移する
    public void movePlayscene()
    {
        SceneManager.LoadScene("playScene");
    }

}
