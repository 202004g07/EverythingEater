using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    float FadeTime = 1;
    [SerializeField]
    float CharEatWaitTime = 0.5f;
    [SerializeField]
    Text StartText;
    [SerializeField]
    Transform EatPlayer;
    [SerializeField]
    float MoveDistance = 0.58f;
    [SerializeField]
    float Increment = 0.1f;

    private Color TextColor;
    private Color BGColor;
    private string StartTextStr;
    private bool IsStart = false;
    private void Start()
    {
        TextColor = StartText.color;
        BGColor = Camera.main.backgroundColor;
    }
    //move .58pos
    void Update()
    {
        if (!IsStart)
        {
            if (Input.anyKey)
            {
                IsStart = true;

                StartCoroutine(CharEat());
                StartCoroutine(MoveEater());
            }
            StartText.color = Color.Lerp(TextColor, BGColor, Mathf.PingPong(Time.time, 1));
            return;
        }

        StartText.color = TextColor;
    }
    /// <summary>
    /// テキスト文末を一文字ずつ減らすコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator CharEat()
    {
        StartTextStr = StartText.text;
        var len = StartTextStr.Length - 1;

        for (int i = len; i >= 0; i--)
        {
            var removeStr = StartTextStr.Remove(i);
            StartText.text = removeStr;
            Debug.Log(removeStr);

            yield return new WaitForSeconds(CharEatWaitTime);
        }
        FadeManager.Instance.LoadScene("GameScene", FadeTime);
    }
    /// <summary>
    /// 食べながら大きくなる
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveEater()
    {
        while (true)
        {
            EatPlayer.position -= new Vector3(MoveDistance, 0);
            EatPlayer.localScale += Vector3.one * Increment;

            yield return new WaitForSeconds(CharEatWaitTime);
        }
    }
}
