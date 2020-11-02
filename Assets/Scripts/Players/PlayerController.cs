using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float DividableSize = 1;
    [SerializeField]
    float InjectionPower = 10;

    private SpriteRenderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input Space");
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
        return Mathf.Sqrt(size);
    }
    /// <summary>
    /// 可能であれば分裂する
    /// </summary>
    public void Divide()
    {
        Debug.Log("Try Divide");
        var nowSize = m_Renderer.bounds.size.x * m_Renderer.bounds.size.y;
        if (nowSize < DividableSize) return;
        Debug.Log("Do Divide");
        var halfSide = HalfAreaSide(nowSize);

        var dividePos = new Vector2(transform.position.x, transform.position.y);
        var player = Instantiate(gameObject, dividePos, Quaternion.identity);

        player.transform.localScale = new Vector3(halfSide, halfSide, 1);
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * InjectionPower);
    }
}
