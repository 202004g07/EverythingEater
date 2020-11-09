using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    /// <summary>
    /// 時間切れ時の処理イベント
    /// </summary>
    [SerializeField]
    private UnityEvent OnTimeOver = new UnityEvent();
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private GameSetting gameSetting;

    bool isInvoked = false;
    void Update()
    {
        timer.Update();
        if (timer.IsTimeOver && !isInvoked)
        {
            isInvoked = true;
            OnTimeOver.Invoke();
        }
    }
}