using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    [SerializeField]
    Text FinishSizeText;
    [SerializeField]
    Text GoalSize;
    [SerializeField]
    EatableObjSO Player;
    //[SerializeField]
    //GameSetting gameSetting;

    void Start()
    {
        var integer = Mathf.Floor(Player.Size);
        var AfterTheDecimalPoint = (Player.Size - integer) * 100;
        FinishSizeText.text = $"あなたのさいず:{integer}㍍ {AfterTheDecimalPoint:00}㌢";
        GoalSize.text = $"もくひょうのおおきさ：{GameDirector.Instance.GoalSize}㍍";
        Debug.Log(AfterTheDecimalPoint);
    }
}
