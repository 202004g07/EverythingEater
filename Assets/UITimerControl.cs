using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimerControl : MonoBehaviour
{
    [SerializeField]
    Timer timer;
    [SerializeField]
    Image timerSprite;

    private void Start()
    {
        StartCoroutine(ClockTimer());
    }
    IEnumerator ClockTimer()
    {
        while (!timer.IsTimeOver)
        {
            var ratio = 1 - timer.Time / timer.StartTime;
            timerSprite.fillAmount = ratio;

            yield return new WaitForFixedUpdate();
        }
    }
}
