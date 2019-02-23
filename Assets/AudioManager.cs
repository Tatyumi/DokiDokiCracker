using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    AudioSource audioSource;
    /// <summary>タイトルシーンのBGM</summary>
    public AudioClip TitleSceneBGM;
    /// <summary>クラッカーの発射音</summary>
    public AudioClip CrackerFire;
    /// <summary>プレイシーンのBGM</summary>
    public AudioClip PlaySceneBGM;
    /// <summary>全オウディオ保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> AudioDic;

    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }


        //シーンが遷移しても破棄されない
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.GetComponent<AudioSource>();

        if (PlaySceneBGM)
        {
            Debug.Log("よし");
        }

        // オウディオを格納
        AudioDic = new Dictionary<string, AudioClip> {
            { TitleSceneBGM.name, TitleSceneBGM},
            { CrackerFire.name, CrackerFire },
            { PlaySceneBGM.name, PlaySceneBGM },
        };
    }

    // Use this for initialization
    void Start()
    {
    }

    /// <summary>
    /// タイトルシーンのBGMを再生
    /// </summary>
    //public void StartTitleBgm()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.PlayOneShot(TitleBGM, 0.5f);
    //}

    /// <summary>
    /// 音を流す
    /// </summary>
    /// <param name="soundName">音の名前</param>
    public void PlaySound(string soundName)
    {
        // 名前のチェック
        if (!AudioDic.ContainsKey(soundName))
        {
            Debug.Log(soundName + "という名前のSEがありません");
            return;
        }
        audioSource.PlayOneShot(AudioDic[soundName]);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopSound()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// プレイシーンのBGMを再生
    /// </summary>
    //public void StartPlayBgm()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.PlayOneShot(PlayBGM, 0.5f);
    //}

    /// <summary>
    /// クラッカーの発射音を再生
    /// </summary>
    //public void StartCrackerFire()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.PlayOneShot(CrackerFire, 0.5f);
    //}
}
