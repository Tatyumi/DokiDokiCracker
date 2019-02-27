using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    // 定数クラス
    public static class Constans
    {
        // サウンド名
        /// <summary>タイトルシーンBGM</summary>
        public const string TITLE_SCENE_BGM = "TitleSceneBGM";
        /// <summary>プレイシーンBGM</summary>
        public const string PLAY_SCENE_BGM = "PlaySceneBGM";
        /// <summary>クラッカー発射SE</summary>
        public const string CRACKER_SCENE_SE = "CrackerFireSE";

        // シーン名
        /// <summary>タイトルシーン名</summary>
        public static string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>プレイシーン名</summary>
        public static string PLAY_SCENE_NAME = "PlayScene";

        // オブジェクト名
        public static string AUDIO_MANAGER = "AudioManager";

        /// <summary>クラッカーの初期長さ</summary>
        public const float CRACKER_FILLAMOUNT = 0.97f;
    }
}