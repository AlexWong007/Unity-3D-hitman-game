using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", Points1.points + 2);
        for (int i = 0; i < Buttons.Length; i++)
        {
            if(i + 2 > levelAt)
            {
                Buttons[i].interactable = false;
            }


        }
    }

    
}
