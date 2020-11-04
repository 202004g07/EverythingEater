using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 捕食者にアタッチするスクリプト
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Eat : MonoBehaviour
{
    [SerializeField]
    float Ratio;

    private Transform m_Trans;
    private SpriteRenderer m_Sprite;
    private float m_Size => m_Sprite.bounds.size.x * m_Sprite.bounds.size.y;
    void Start()
    {
        m_Trans = transform;
        m_Sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hitObjSprite = collision.gameObject.GetComponent<SpriteRenderer>();
        var hitObjSize = hitObjSprite.bounds.size.x * hitObjSprite.bounds.size.y;
        if (m_Size < hitObjSize) return;

        var playerScale = m_Trans.localScale;
        playerScale += Vector3.one * (hitObjSize / Ratio);

        m_Trans.localScale = playerScale;

        Destroy(collision.gameObject);
    }
}
