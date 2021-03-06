﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オーディオ管理クラス．シングルトン．
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    AudioSource audioSource;
    /// <summary>タイトルシーンのBGM</summary>
    public AudioClip TitleSceneBGM;
    /// <summary>クラッカーの発射音</summary>
    public AudioClip CrackerFire;
    /// <summary>プレイシーンのBGM</summary>
    public AudioClip PlaySceneBGM;
    /// <summary>全オーディオ保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> AudioDic;

    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        audioSource = gameObject.GetComponent<AudioSource>();

        // オーディオを格納
        AudioDic = new Dictionary<string, AudioClip> {
            { TitleSceneBGM.name, TitleSceneBGM},
            { CrackerFire.name, CrackerFire },
            { PlaySceneBGM.name, PlaySceneBGM },
        };
    }

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

}
