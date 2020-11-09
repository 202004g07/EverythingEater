using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameSetting : ScriptableObject
{
    [Header("面の名前")]
    [SerializeField]
    string Name;
    [Header("目標サイズ")]
    public float GaolSize;
    [Header("制限時間")]
    public int Time;
}
