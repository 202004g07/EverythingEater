using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeManager : MonoBehaviour
{
    [SerializeField]
    private Timer Timer;
    [SerializeField]
    private Text Time;

    void Update()
    {
        Time.text = Timer.Time.ToString(format: "00");
    }
}
