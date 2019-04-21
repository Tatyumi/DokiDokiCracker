using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class TitleDirector : MonoBehaviour {

    //private GameObject audioManager;
    private AudioManager audioManager;

    private void Awake()
    {
        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;
    }

    // Use this for initialization
    void Start()
    {
        //タイトルのBGMを再生
        audioManager.PlaySound(SoundName.TITLE_SCENE_BGM);
    }

    // Update is called once per frame
    void Update()
    {
        //画面をタップした場合
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.StopSound();
            SceneManager.LoadScene(SceneName.PLAY_SCENE_NAME);
        }
    }
    
}
