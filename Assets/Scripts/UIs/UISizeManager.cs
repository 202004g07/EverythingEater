using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISizeManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform PlayerUI;
    [SerializeField]
    private RectTransform TargetUI;
    [SerializeField]
    private Text Size;
    [SerializeField]
    private Text GoalSizeT;
    [SerializeField]
    private float MaxSize = 462;


    private float PlayerScale;
    private float BaffaPlayerSize;
    private float GoalSize;
    private float Ratio;
    private void Awake()
    {
        GoalSize = GameDirector.Instance.GoalSize;
        PlayerScale = Player.Biggest.localScale.x;
        GoalSizeT.text = $"{GoalSize}㍍";

        Ratio = (TargetUI.rect.width - PlayerUI.rect.width) / (GoalSize - PlayerScale);
    }
    private void Update()
    {
        BaffaPlayerSize = PlayerScale;

        var diff = Player.Biggest.localScale.x - BaffaPlayerSize;

        if (PlayerUI.sizeDelta.x < MaxSize) PlayerUI.sizeDelta += new Vector2(Ratio * diff, Ratio * diff);

        PlayerScale = Player.Biggest.localScale.x;

        var sizeAfterDecimal = GetAfterDecimalPoint(PlayerScale) * 100;
        Size.text = $"{Mathf.FloorToInt(PlayerScale)}㍍{sizeAfterDecimal:00}㌢";
    }
    /// <summary>
    /// 小数点以下を返すメソッド
    /// </summary>
    /// <param name="num">
    /// </param>
    /// <returns></returns>
    private float GetAfterDecimalPoint(float num)
    {
        return num % 1;
    }
}
