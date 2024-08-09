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
    public const string LASTSELECTCHAPTER = "lastSelectChap";

    //level Data
    public static int SelectedLv = 0;

    //json path
    public const string PLAYEDDATAPATH = "DataChap";

    public static bool ReturnFromGame = false;
}
