using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;


public class StringController : MonoBehaviour
{
    /// <summary>プルガイド</summary>
    public GameObject PullGuide;
    /// <summary>クラッカーの紐の画像</summary>
    public Image Stringimg;
    /// <summary>PlayDirectorをゲームオブジェクトにアタッチ</summary>
    public GameObject PlayObj;
    /// <summary>プレイディレクター</summary>
    public PlayDirector PlayDirector;

    /// <summary>クラッカーが発射される紐の長さ</summary>
    private float limitFillAmount = 0.0f;
    /// <summary>ゲームエンド間での間をカウント</summary>
    private int count = 0;
    /// <summary>ゲームが終了したかどうか判定を行う</summary>
    private bool isGameEnd = false;
    /// <summary></summary>
    private float nextTime;
    /// <summary>プルガイド表示フラグ</summary>
    private bool isDisplayPullGuide = true;

    /// <summary>タップした位置</summary>
    Vector2 touchPos = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        // 現在時刻の取得
        nextTime = Time.time;

        // 紐の長さの初期化
        Stringimg.fillAmount = Constans.STRING_FILLAMOUNT;

        // クラッカーが暴発する紐の長さ(ランダムで決めるようにする)
        limitFillAmount = Random.Range(Constans.STRING_FILLAMOUNT + 0.05f, Constans.MAX_STRING_FILLAMOUNT);
        Debug.Log(limitFillAmount);

    }

    // Update is called once per frame
    void Update()
    {
        // ゲームが終了したかどうか判定
        if (isGameEnd == false)
        {
            // 終了していない，ゲーム続行中の場合

            // 画面をタップしているか判別
            if (Input.GetMouseButton(0))
            {
                // プルガイドを非表示
                PullGuide.SetActive(false);

                // 紐の長さが限界値か判別
                if (Stringimg.fillAmount > limitFillAmount)
                {
                    PlayDirector.FireCracker();
                    isGameEnd = true;

                    // 端末がバイブレーション対応かどうか判別
                    if (SystemInfo.supportsVibration)
                    {
                        // バイブレーションを起動
                        Handheld.Vibrate();
                    }
                }

                // タップした箇所が下に移動しているか判別
                if (touchPos.y > Input.mousePosition.y)
                {
                    Stringimg.fillAmount += Constans.STRING_PULL;
                }
                // タップした位置のy座標を取得
                touchPos.y = Input.mousePosition.y;
            }
            else
            {
                // 一定の周期でガイドの表示を行う
                if (Time.time > nextTime)
                {
                    PullGuide.SetActive(isDisplayPullGuide);
                    isDisplayPullGuide = !isDisplayPullGuide;
                    nextTime += Constans.GUIDETEXT_DISPLAY_INTERVAL;
                }
            }
        }
        else
        {
            // ゲーム終了の場合

            // ゲーム終了後一定時間が経ったか判別
            if (count == Constans.END_TIME)
            {
                // コンティニューパネルを表示
                PlayDirector.DisplayCountinuePanel();
            }
            else
            {
                // カウントアップ（時間計測）
                count++;
            }
        }
    }
}
