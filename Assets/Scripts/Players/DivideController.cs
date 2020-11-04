using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class DivideController : MonoBehaviour
{
    [SerializeField]
    float DividableSize = 1;
    [SerializeField]
    float InjectionPower = 10;
    //[SerializeField]
    //GameObject PlayerPrefab;

    //TODO スケールでプレイヤーのサイズを扱うのかRendererのBoundsで扱うのかをしっかり決める
    // private SpriteRenderer m_Renderer;
    private Transform m_Trans;
    void Start()
    {
        //   m_Renderer = GetComponent<SpriteRenderer>();
        m_Trans = transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Divide();
        }
    }
    /// <summary>
    /// 半分の面積の辺の長さを返す.
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public float HalfAreaSide(float size)
    {
        return Mathf.Sqrt(size / 2);
    }
    /// <summary>
    /// 可能であれば分裂する
    /// </summary>
    public void Divide()
    {
        //var nowSize = m_Renderer.bounds.size.x * m_Renderer.bounds.size.y;
        var nowSize = m_Trans.localScale.x * m_Trans.localScale.y;
        Debug.Log(nowSize);
        if (nowSize < DividableSize) return;

        var halfSide = HalfAreaSide(nowSize);
        var halfScale = new Vector3(halfSide, halfSide, 1);

        var dividePos = new Vector2(m_Trans.position.x + halfSide, m_Trans.position.y + halfSide);
        var player = Instantiate(gameObject, dividePos, Quaternion.identity);

        gameObject.transform.localScale = halfScale;

        player.tag = "Player";
        player.transform.localScale = halfScale;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * InjectionPower);
    }

}
