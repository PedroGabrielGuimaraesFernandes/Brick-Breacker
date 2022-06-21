using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public static int[] levelStatus = { 1, 0, 0 };
    public static int[] levelHighscores = { 0, 0, 0};

    public static void SaveLevelStatus()
    {
        PlayerPrefsX.SetIntArray("levelStatus", levelStatus);
    }

   public static void SaveHighscore()
    {
        PlayerPrefsX.SetIntArray( "highscores",levelHighscores);
    }

    public static void LoadData()
    {        
        if (PlayerPrefs.HasKey("levelStatus"))
        {
            levelStatus = PlayerPrefsX.GetIntArray("levelStatus");
        }
        else
        {
            levelStatus = new int[] { 1, 0, 0 };
        }


        if (PlayerPrefs.HasKey("highscores"))
        {
            levelHighscores = PlayerPrefsX.GetIntArray("highscores");
        }
        else
        {
            levelHighscores = new int[] { 0, 0, 0 };
        }
    }

    public static void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

}
