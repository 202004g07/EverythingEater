using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbsorbController : MonoBehaviour
{
    private List<GameObject> Players;
    private void Awake()
    {
        Players = new List<GameObject>() { };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Absorb();
        }

    }

    void Absorb()
    {
        Players = GameObject.FindGameObjectsWithTag("Player").ToList(); ;
        if (Players.Count == 0) return;

        var addSize = 0f;
        foreach (var p in Players)
        {
            addSize += p.transform.localScale.x * p.transform.localScale.y;
            Destroy(p);
        }
        Players.Clear();

        var m_Scale = transform.localScale;
        var m_Size = m_Scale.x * m_Scale.y;

        var addSizeSide = Mathf.Sqrt(m_Size + addSize);
        gameObject.transform.localScale = new Vector3(addSizeSide, addSizeSide, 1);
    }
}
