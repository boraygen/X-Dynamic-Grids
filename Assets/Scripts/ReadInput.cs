using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{
    string input;
    [SerializeField] Button playButton;

    void Awake()
    {
        playButton.interactable = false;
    }

    public void ReadStringInput(string str)
    {
        bool numberOnly = Regex.IsMatch(str, @"^\d+$");

        if (numberOnly)
        {
            float value = float.Parse(str);

            if (value >= 2 && value <= 200)
            {
                playButton.interactable = true;
            }
            else
            {
                value = 0;
                playButton.interactable = false;
            }
        }
        else
        {
            playButton.interactable = false;
        }
    }
    

    public void LoadGame(string str)
    {
        int value = int.Parse(str);

        if (value >= 2 && value <= 200)
        {
            GridManager.staticGridFactor = value;
            SceneManager.LoadScene(1);
        }
    }
}
