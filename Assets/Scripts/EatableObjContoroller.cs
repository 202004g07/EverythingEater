using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class EatableObjContoroller : MonoBehaviour, IEatable
{
    [SerializeField]
    private SpriteRenderer Player;
    [SerializeField]
    private float Ratio = 10;

    private float PlayerSize;
    private SpriteRenderer Renderer;
    private float ObjSize;
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        ObjSize = Renderer.bounds.size.x * Renderer.bounds.size.y;
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
}
