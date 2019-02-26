using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;


public class StringController : MonoBehaviour
{
    /// <summary>プルガイド</summary>
    public GameObject PullGuide;
    /// <summary>エンドパネル</summary>
    public GameObject EndPanel;
    /// <summary>エンドエフェクト</summary>
    public GameObject EndEffect;
    /// <summary>クラッカーの紐の画像</summary>
    public Image Stringimg;
    /// <summary>PlayDirectorをゲームオブジェクトにアタッチ</summary>
    public GameObject PlayObj;
    /// <summary>プレイディレクター</summary>
    private PlayDirector PlayDirector;
    /// <summary>クラッカーの紐の長さ</summary>
    private const float STRING_FILLAMOUNT = 0.35f;
    /// <summary>クラッカーの紐を引く速さ</summary>
    private const float STRING_PULL = 0.004f;
    /// <summary>クラッカーの紐の最大の長さ</summary>
    private const float MAX_STRING_FILLAMOUNT = 1.0f;
    /// <summary>クラッカーが発射される紐の長さ</summary>
    private float limitFillAmount = 0.0f;
    /// <summary>ゲームエンド間での時間（クラッカー発射後から終了表示までの時間）</summary>
    private const int END_TIME = 110;
    /// <summary>ゲームエンド間での間をカウント</summary>
    private int count = 0;
    /// <summary>ゲームが終了したかどうか判定を行う</summary>
    private bool isGameEnd = false;
    /// <summary>タップした位置</summary>
    Vector2 touchPos = new Vector2(0, 0);
    private GameObject audioObj;

    private float nextTime;
    public const float INTERVAL_TIME = 1.0f;   // 点滅周期
    //プルのレンダー切り替えフラグ
    private bool isPullRen = true;

    private void Awake()
    {
        audioObj = GameObject.Find(Constans.AUDIO_MANAGER);
    }

    // Use this for initialization
    void Start()
    {
        
        //プレイシーンののBGMを再生
        audioObj.GetComponent<AudioManager>().PlaySound(Constans.PLAY_SCENE_BGM);
        //現在時刻の取得
        nextTime = Time.time;
        PlayDirector = PlayObj.GetComponent<PlayDirector>();

        //紐の長さの初期化
        Stringimg.fillAmount = STRING_FILLAMOUNT;

        //クラッカーが暴発する紐の長さ(ランダムで決めるようにする)
        limitFillAmount = Random.Range(STRING_FILLAMOUNT + 0.05f, MAX_STRING_FILLAMOUNT);
        Debug.Log(limitFillAmount);

        //終了演出に使用するオブジェクトを非表示
        EndEffect.SetActive(false);
        EndPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //ゲームが終了したかどうか判定
        if (isGameEnd == false)
        {
            //終了していない，ゲーム続行中の場合

            //画面をタップしているか判別
            if (Input.GetMouseButton(0))
            {
                //プルガイドを非表示
                PullGuide.SetActive(false);
                //紐の長さが限界値か判別
                if (Stringimg.fillAmount > limitFillAmount)
                {
                    PlayDirector.FireCracker();
                    Debug.Log("BAN!");
                    audioObj.GetComponent<AudioManager>().StopSound();
                    audioObj.GetComponent<AudioManager>().PlaySound(Constans.CRACKER_SCENE_SE);
                    isGameEnd = true;

                    //端末がバイブレーション対応かどうか判別
                    if (SystemInfo.supportsVibration)
                    {
                        //バイブレーションを起動
                        Handheld.Vibrate();
                    }
                }

                //タップした箇所が下に移動しているか判別
                if (touchPos.y > Input.mousePosition.y)
                {
                    Stringimg.fillAmount += STRING_PULL;
                }
                //タップした位置のy座標を取得
                touchPos.y = Input.mousePosition.y;
            }
            else
            {
                //一定の周期でガイドの表示を行う
                if (Time.time > nextTime)
                {
                    PullGuide.SetActive(isPullRen);
                    isPullRen = !isPullRen;
                    nextTime += INTERVAL_TIME;
                }
            }
        }
        else
        {
            //ゲーム終了の場合

            //一定の時間がたったら
            if (count == END_TIME)
            {
                EndEffect.SetActive(true);
                EndPanel.SetActive(true);
            }
            else
            {
                //カウンとアップ（時間計測）
                count++;
            }
        }
    }
}
