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
    public const string LV = "lv"; //x
    public const string CURRENTCHAPTER = "currentChapter"; 
    public const string LASTSELECTCHAPTER = "lastSelectChap"; //x
    public const string LIFE = "life";
    public const string TOTALSTAR = "totalStar";
    public const string BESTSTREAK = "bestStreak";

    //level Data
    public static int SelectedLv = 0;
    public static int SelectedChap = 1;

    //json path
    public const string PLAYEDDATAPATH = "DataChap";

    public static bool ReturnFromGame = false;

    //default value
    public const int DEFAULTLIFE = 3;
    public const int MAXCHAP = 2;

    //Mode
    public static bool IsArcadeMode = false;
    public static int Streak = 0;
}
