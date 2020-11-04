using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISizeManager : MonoBehaviour
{
    // [SerializeField]
    //private Transform Player;
    [SerializeField]
    private RectTransform PlayerUI;
    [SerializeField]
    private RectTransform TargetUI;
    [SerializeField]
    private Text Size;
    [SerializeField]
    private Text GoalSizeT;
    //TODO ゲームマネージャーとかディレクター側で設定するように変更
    [SerializeField]
    private float GoalSize = 30;
    [SerializeField]
    private float MaxSize = 462;

    private float PlayerScale;
    private float BaffaPlayerSize;

    private float Ratio;
    private void Awake()
    {
        PlayerScale = Player.BiggestPlayer.localScale.x;
        GoalSizeT.text = $"{GoalSize}㍍";

        Ratio = (TargetUI.rect.width - PlayerUI.rect.width) / (GoalSize - PlayerScale);
    }
    private void Update()
    {
        BaffaPlayerSize = PlayerScale;

        var diff = Player.BiggestPlayer.localScale.x - BaffaPlayerSize;

        if (PlayerUI.sizeDelta.x < MaxSize) PlayerUI.sizeDelta += new Vector2(Ratio * diff, Ratio * diff);

        PlayerScale = Player.BiggestPlayer.localScale.x;

        var sizeAfterDecimal = GetAfterDecimalPoint(PlayerScale) * 10;
        Size.text = $"{Mathf.FloorToInt(PlayerScale)}㍍{sizeAfterDecimal:0}㌢";
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
    /// <summary>
    /// シーン内に存在するPlayerの中で最も大きいプレイヤーのTrasfromを返す
    /// </summary>
    //public Transform BiggestPlayer
    //{
    //    get
    //    {
    //        var players = new List<GameObject>();
    //        players = GameObject.FindGameObjectsWithTag("Player").ToList();

    //        return players.OrderByDescending(p => p.transform.localScale.x).First().transform;
    //    }
    //}
}
