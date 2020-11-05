using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class EatableObjContoroller : MonoBehaviour, IEatable
{
    [SerializeField]
    EatableObjSO objSO;
    [SerializeField]
    UIEatenView UIEaten;

    private Renderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }
    /// <summary>
    /// 自分自身のサイズのプロパティ
    /// </summary>
    public float ObjSize => m_Renderer.bounds.size.x * m_Renderer.bounds.size.y;

    private void OnDestroy()
    {
        UIEaten.View(objSO);
    }
}
