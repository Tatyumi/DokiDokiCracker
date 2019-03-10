using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class TitleDirector : MonoBehaviour {

    private GameObject gameObj;

    private void Awake()
    {
        gameObj = GameObject.Find(ObjectName.AUDIO_MANAGER);
    }

    // Use this for initialization
    void Start()
    {
        //タイトルのBGMを再生
        gameObj.GetComponent<AudioManager>().PlaySound(SoundName.TITLE_SCENE_BGM);
    }

    // Update is called once per frame
    void Update()
    {
        //画面をタップした場合
        if (Input.GetMouseButtonDown(0))
        {
            gameObj.GetComponent<AudioManager>().StopSound();
            SceneManager.LoadScene(SceneName.PLAY_SCENE_NAME);
        }
    }
    
}
