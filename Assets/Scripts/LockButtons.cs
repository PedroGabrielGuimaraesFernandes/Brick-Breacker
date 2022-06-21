using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButtons : MonoBehaviour
{
    //public Button[] buttons;
    public GameObject[] fases;
    private void Awake()
    {
        GameData.LoadData();
    }

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < fases.Length; i++)
        {
            if (GameData.levelStatus[i] > 0)
            {
                fases[i].SetActive(true);
            }
            else
            {
                fases[i].SetActive(false);
            }

        }

    }

    public void ResetData()
    {
        GameData.ResetData();
    }

    /*public void LevelUnlocker()
    {
        //SaveAndLoad.UnlockLevels();
        //SaveAndLoad.SaveData();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (GameData.levelStatus[i] > 0)
            {
                fases[i].SetActive(true);
            }
            else
            {
                fases[i].SetActive(false);
            }
        }
    }*/
}
