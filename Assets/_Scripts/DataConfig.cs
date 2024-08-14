using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConfig 
{
    //scene
    public const int MENUSCENE = 0;
    public const int MAINSCENE = 1;

    //Player prefs
    public const string CURRENTLV = "currentLv";
    public const string CURRENTCHAPTER = "currentChapter"; 
    public const string LIFE = "life";
    public const string TOTALSTAR = "totalStar";
    public const string BESTSTREAK = "bestStreak";
    public const string SOUND = "sound";
    public const string MUSIC = "music";
    public const string VIBRATION = "vibration";

    //level Data
    public static int SelectedLv = 0;
    public static int SelectedChap = 1;

    //json path
    public const string PLAYEDDATAPATH = "DataChap";

    public static bool ReturnFromGame = false;

    //default value
    public const int DEFAULTLIFE = 100;
    public const int MAXCHAP = 2;
    public const int DEFAULTARCADECLICKS = 5;

    //Mode
    public static bool IsArcadeMode = false;
    public static int Streak = 0;
}
