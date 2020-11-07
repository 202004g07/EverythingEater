﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    Timer timer;
    [SerializeField]
    EatableObjSO PlayerSO;
    [SerializeField]
    GameObject FinishUI;
    [SerializeField]
    float time;
    [SerializeField]
    Ease ease;
    public float GoalSize;

    private void Start()
    {
        FinishUI.SetActive(false);
        Screen.SetResolution(1024, 576, false, 60);
    }
    private void Update()
    {
        PlayerSO.Size = Player.BiggestSize;
        Debug.Log(PlayerSO.Size);
    }
    public void OnGameOver()
    {
        FinishUI.SetActive(true);

        //  Time.timeScale = 0;
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
