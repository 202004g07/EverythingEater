using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EatableObjSO : ScriptableObject
{
    /// <summary>
    /// 自身の名前
    /// </summary>
    public string Name;
    /// <summary>
    /// 自身のスプライト
    /// </summary>
    public Sprite m_Sprite;
    public float InitSize;
    public float Size { get; set; }

    private void OnEnable()
    {
        Init();
    }
    public void Init()
    {
        Size = InitSize;
    }
}
