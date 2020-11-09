using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    GameSetting gameSetting;
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
    public float GoalSize => gameSetting.GaolSize;

    #region Singleton

    private static GameDirector instance;

    public static GameDirector Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameDirector)FindObjectOfType(typeof(GameDirector));

                if (instance == null)
                {
                    Debug.LogError(typeof(GameDirector) + "is nothing");
                }
            }

            return instance;
        }
    }

    #endregion Singleton

    //public void Awake()
    //{
    //    if (this != Instance)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    DontDestroyOnLoad(this.gameObject);
    //}
    private void Start()
    {
        FinishUI.SetActive(false);
        //GoalSize = gameSetting.GaolSize;
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
