using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;

    private Transform Trans;
    private Rigidbody2D rd;
    private float h;
    private float v;
    private Vector3 playerPos;

    private void Start()
    {
        Trans = GetComponent<Transform>();
        rd = GetComponent<Rigidbody2D>();
        playerPos = Trans.position;
    }
    void Update()
    {
        h = Input.GetAxis("Hori");
        v = Input.GetAxis("Ver");

        var inputVector = new Vector2(h, v);

        rd.velocity = inputVector.normalized * Speed;

        Vector2 diff = Trans.position - playerPos;

        if (diff.magnitude > 0.05f)
        {
            Trans.rotation = Quaternion.FromToRotation(Vector3.right, diff);
        }
        playerPos = Trans.position;
    }

}
