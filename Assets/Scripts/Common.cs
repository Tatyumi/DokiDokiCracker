using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonConstans
{
    public static class SoundName
    {
        // サウンド名
        /// <summary>タイトルシーンBGM</summary>
        public const string TITLE_SCENE_BGM = "TitleSceneBGM";
        /// <summary>プレイシーンBGM</summary>
        public const string PLAY_SCENE_BGM = "PlaySceneBGM";
        /// <summary>クラッカー発射SE</summary>
        public const string CRACKER_SCENE_SE = "CrackerFireSE";
    }

    // シーン名
    public static class SceneName
    {
        // シーン名
        /// <summary>タイトルシーン名</summary>
        public static string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>プレイシーン名</summary>
        public static string PLAY_SCENE_NAME = "PlayScene";
    }

    // オブジェクト名
    public static class ObjectName
    {
        // オブジェクト名
        public static string AUDIO_MANAGER = "AudioManager";
    }

    // 値
    public static class Value
    {
        /// <summary>クラッカーの初期長さ</summary>
        public const float CRACKER_FILLAMOUNT = 0.97f;
        /// <summary>紐の横幅</summary>
        public const float STRING_WIDTH = 10.0f;
        /// <summary>クラッカーの紐の長さ</summary>
        public const float STRING_FILLAMOUNT = 0.35f;
        /// <summary>クラッカーの紐を引く速さ</summary>
        public const float STRING_PULL = 0.004f;
        /// <summary>クラッカーの紐の最大の長さ</summary>
        public const float MAX_STRING_FILLAMOUNT = 1.0f;
        /// <summary>ゲームエンド間での時間（クラッカー発射後から終了表示までの時間）</summary>
        public const int END_TIME = 110;
        /// <summary>ガイドテキストの点滅周期時間</summary>
        public const float GUIDETEXT_DISPLAY_INTERVAL = 1.0f;
    }
}