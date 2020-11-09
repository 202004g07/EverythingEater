using UnityEngine;

[CreateAssetMenu]
public class Timer : ScriptableObject
{
    public int StartTime { get; private set; }
    [SerializeField]
    GameSetting gameSetting;
    public float Time { get; private set; }
    /// <summary>
    /// Timeが0以下かの判定を行う
    /// </summary>
    public bool IsTimeOver => Time <= 0;

    /// <summary>
    /// 有効になったタイミングで初期化。
    /// </summary>
    void OnEnable()
    {
        Reset();
    }

    /// <summary>
    /// 時間が減る処理
    /// </summary>
    public void Update()
    {
        if (IsTimeOver)
        {
            Time = 0;
            return;
        }
        Time -= UnityEngine.Time.deltaTime;
    }
    /// <summary>
    /// 初期値に戻す処理
    /// </summary>
    public void Reset()
    {
        StartTime = gameSetting.Time;
        Time = StartTime;
    }
}