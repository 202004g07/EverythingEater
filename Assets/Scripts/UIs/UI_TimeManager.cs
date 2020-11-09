using DG.Tweening;
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
    [SerializeField]
    GameObject FinishUI;
    [SerializeField]
    float time;
    [SerializeField]
    Ease ease;

    private void Start()
    {
        FinishUI.SetActive(false);
    }
    void Update()
    {
        Time.text = Timer.Time.ToString(format: "00");
    }
    public void OnGameOver()
    {
        FinishUI.SetActive(true);

        var finishUITrans = FinishUI.transform;
        var transCashe = finishUITrans.localScale;

        finishUITrans.localScale = Vector3.zero;

        finishUITrans.DOScale(transCashe, time).SetEase(ease)
                                          .SetUpdate(true)
                                          .OnComplete(() =>
                                          {
                                              FadeManager.Instance.LoadScene("GameOverScene", time);
                                          });
    }
}
