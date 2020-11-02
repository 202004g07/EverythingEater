﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class EatableObjContoroller : MonoBehaviour, IEatable
{
    [SerializeField]
    private EatableObjSO m_SO;
    [SerializeField]
    private SpriteRenderer Player;
    [SerializeField]
    private float Ratio = 10;

    private float PlayerSize;
    private Renderer m_Renderer;
    private float ObjSize => m_Renderer.bounds.size.x * m_Renderer.bounds.size.y;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// 食べられたときプレイヤーを大きくする処理を行う。
    /// </summary>
    public void Eaten()
    {
        if (!IsEatable()) return;

        var playerScale = Player.transform.localScale;
        playerScale += Vector3.one * (ObjSize / Ratio);

        Player.transform.localScale = playerScale;

        Destroy(gameObject);
    }
    /// <summary>
    /// 食べられるかどうかの判定を行う。
    /// </summary>
    /// <returns></returns>
    public bool IsEatable()
    {
        PlayerSize = Player.bounds.size.x * Player.bounds.size.y;
        if (PlayerSize >= ObjSize)
        {
            return true;
        }
        return false;
    }
    //TODO: 増殖したプレイヤーが相互捕食できるようにしたい
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var hitObj = collision.gameObject.GetComponent<SpriteRenderer>();

    //    if (/*!hitObj.CompareTag("Player") && */hitObj == null) return;

    //    Player = hitObj;
    //    PlayerSize = Player.bounds.size.x * Player.bounds.size.y;
    //}
}
