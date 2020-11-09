using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [Header("LevelのSO")]
    [SerializeField]
    GameSetting gameSetting;
    [SerializeField]
    Timer timer;

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

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void DestroySelf()
    {
        Destroy(this);
    }
}
