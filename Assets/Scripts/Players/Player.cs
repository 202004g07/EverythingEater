using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 自分がメインプレイヤー（最も大きいプレイヤー）かどうかをチェックしたりするクラス
/// </summary>
public static class Player
{
    /// <summary>
    /// シーンビュー上で最も大きいプレイヤーのTransを返す。
    /// </summary>
    public static Transform BiggestPlayer
    {
        get
        {
            var players = new List<GameObject>();
            players = GameObject.FindGameObjectsWithTag("Player").ToList();

            return players.OrderByDescending(p => p.transform.localScale.x).First().transform;
        }
    }
    /// <summary>
    /// 引数に自分自身を渡し、最も大きいプレイヤーであればTrueを返す。
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static bool IsMainPlayer(GameObject gameObject) => BiggestPlayer == gameObject;
    public static int Count() => GameObject.FindGameObjectsWithTag("Player").Length;
}
