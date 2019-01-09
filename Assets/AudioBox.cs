using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    AudioSource audioSource;
    /// <summary>田井徹画面のBGM</summary>
    public AudioClip titleBgm;
    /// <summary>クラッカーの発射音</summary>
    public AudioClip crackerFire;
    /// <summary>プレイシーンのBGM</summary>
    public AudioClip playBgm;

    // Use this for initialization
    void Start()
    {
        //シーンが遷移しても破棄されない
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// タイトルシーンのBGMを再生
    /// </summary>
    public void StartTitleBgm()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(titleBgm, 0.5f);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopMusic()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// プレイシーンのBGMを再生
    /// </summary>
    public void StartPlayBgm()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(playBgm, 0.5f);
    }

    /// <summary>
    /// クラッカーの発射音を再生
    /// </summary>
    public void StartCrackerFire()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(crackerFire, 0.5f);
    }
}
