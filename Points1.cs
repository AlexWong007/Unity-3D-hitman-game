using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points1 : MonoBehaviour
{
    [SerializeField] Text pointText;

    public static int points = 0;
    
    private void Awake()
    {
        UpdateHUD();

    }

    public int Points { get { return points; }set { points = value; UpdateHUD(); } }

    private void UpdateHUD()
    {
      pointText.text = points.ToString();
    }

}
