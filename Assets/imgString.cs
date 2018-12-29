using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgString : MonoBehaviour
{
    //プルガイド
    public GameObject pullGuide;
    //エンドパネル
    public GameObject endPanel;
    //エンドエフェクト
    public GameObject endEffectObj;
    /// <summary>クラッカーの紐の画像</summary>
    public Image imageString;
    /// <summary>empObjectDirectorをゲームオブジェクトにアタッチ</summary>
    //GameObject eObj;
    public GameObject eObj;
    private empObjectDirector eoScript;
    /// <summary>クラッカーの画像</summary>
    //public GameObject Cracker;
    ///紐の初期fillamont値
    private const float STRING_FILLAMOUNT = 0.35f;
    //紐の引く速さ
    private const float STRING_PULL = 0.004f;
    //紐の長さの最大値
    private const float MAX_STRING_FILLAMOUNT = 1.0f;
    //紐の限界の長さ
    private float limitFillAmount = 0.0f;
    //ゲームエンド間での時間（クラッカー発射後から終了表示までの時間）
    private const int END_TIME = 110;
    //ゲームエンド間での間をカウント
    private int count = 0;
    //ゲームが終了したかどうか判定を行う
    private bool isGameEnd = false;
    //タップした位置
    Vector2 touchPos = new Vector2(0, 0);
    private GameObject audioObj;

    private float nextTime;
    public const float INTERVAL_TIME = 1.0f;   // 点滅周期
    //プルのレンダー切り替えフラグ
    private bool isPullRen = true;

    // Use this for initialization
    void Start()
    {
        audioObj = GameObject.Find("AudioBox");

        //プレイシーンののBGMを再生
        audioObj.GetComponent<AudioBox>().PlayBgmSart();
        //現在時刻の取得
        nextTime = Time.time;
        //eObj = GameObject.Find("ObjectDirector");
        eoScript = eObj.GetComponent<empObjectDirector>();

        //紐の長さの初期化
        imageString.fillAmount = STRING_FILLAMOUNT;

        //クラッカーが暴発する紐の長さ(ランダムで決めるようにする)
        limitFillAmount = Random.Range(STRING_FILLAMOUNT + 0.05f, MAX_STRING_FILLAMOUNT);
        Debug.Log(limitFillAmount);

        //終了演出に使用するオブジェクトを非表示
        endEffectObj.SetActive(false);
        endPanel.SetActive(false);
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
                pullGuide.SetActive(false);
                //紐の長さが限界値か判別
                if (imageString.fillAmount > limitFillAmount)
                {
                    eoScript.crackerFire();
                    Debug.Log("BAN!");
                    audioObj.GetComponent<AudioBox>().audioStop();
                    audioObj.GetComponent<AudioBox>().CrackerFire();
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
                    imageString.fillAmount += STRING_PULL;
                }
                //タップした位置のy座標を取得
                touchPos.y = Input.mousePosition.y;
            }
            else
            {
                //一定の周期でガイドの表示を行う
                if (Time.time > nextTime)
                {
                    pullGuide.SetActive(isPullRen);
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
                endEffectObj.SetActive(true);
                endPanel.SetActive(true);
            }
            else
            {
                //カウンとアップ（時間計測）
                count++;
            }
        }


    }
}
