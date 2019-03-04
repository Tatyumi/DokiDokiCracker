using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class PlayDirector : MonoBehaviour
{
    /// <summary>紐</summary>
    public GameObject String;
    /// <summary>クラッカー</summary>
    public GameObject Cracker;
    /// <summary>発射クラッカー画像</summary>
    public GameObject CrackerFire;
    /// <summary>コンティニューパネル</summary>
    public GameObject ContinuePanel;
    /// <summary>エンドエフェクト</summary>
    public GameObject EndEffect;
    
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find(Constans.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        //紐のサイズ
        RectTransform strRect = String.GetComponent<RectTransform>();
        strRect.sizeDelta = new Vector2(Constans.STRING_WIDTH, Screen.height / 2);

        //クラッカーの初期値位置
        Cracker.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        //発射クラッカーの初期位置
        CrackerFire.transform.position = Cracker.transform.position;

        //紐の初期位置
        String.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        //終了演出に使用するオブジェクトを非表示
        EndEffect.SetActive(false);
        ContinuePanel.SetActive(false);

        //プレイシーンののBGMを再生
        audioManager.PlaySound(Constans.PLAY_SCENE_BGM);
        SetCracker();
    }

    /// <summary>
    /// クラッカーを初期状態にする
    /// </summary>
    public void SetCracker()
    {
        // 未発射のクラッカーを表示
        Cracker.SetActive(true);
        CrackerFire.SetActive(false);
    }

    /// <summary>
    /// クラッカーを発射する
    /// </summary>
    public void FireCracker()
    {
        // 効果音を発射音のみ再生する
        audioManager.StopSound();
        audioManager.PlaySound(Constans.CRACKER_SCENE_SE);

        // 発射クラッカーを表示
        Cracker.SetActive(false);
        CrackerFire.SetActive(true);
    }

    /// <summary>
    /// コンテニューパネルの表示
    /// </summary>
    public void DisplayCountinuePanel()
    {
        EndEffect.SetActive(true);
        ContinuePanel.SetActive(true);
    }
    
    /// <summary>
     /// タイトルシーンに遷移
     /// </summary>
    public void MoveTitleScene()
    {
        SceneManager.LoadScene(Constans.TITLE_SCENE_NAME);
    }

    /// <summary>
    /// プレイシーンに遷移する
    /// </summary>
    public void MovePlayscene()
    {
        SceneManager.LoadScene(Constans.PLAY_SCENE_NAME);
    }
}
