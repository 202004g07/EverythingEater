using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    [SerializeField]
    Text FinishSizeText;
    [SerializeField]
    EatableObjSO Player;

    void Start()
    {
        var integer = Mathf.Floor(Player.Size);
        var AfterTheDecimalPoint = (Player.Size - integer) * 100;
        FinishSizeText.text = $"さいず:{integer}㍍ {AfterTheDecimalPoint:00}㌢";
        Debug.Log(AfterTheDecimalPoint);
    }
}
