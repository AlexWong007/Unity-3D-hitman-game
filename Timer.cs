using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public float time;
    public TextMeshProUGUI text;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        int minutes = (int)((time - time % 60) / 60);
        text.text = minutes.ToString() + ":" + (Mathf.Round(time - minutes * 60)).ToString();
        if (Timer.Instance.time <= 0)
        {
            SceneManager.LoadScene(8);
        }
    }

    void FixedUpdate()
    {
        if (Timer.Instance.time < 0)
        {
            Timer.Instance.time = 0;
        }
    }
}
