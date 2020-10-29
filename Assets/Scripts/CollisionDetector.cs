using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private CollisionEvent onCollisonEnter2D = new CollisionEvent();
    [SerializeField]
    private CollisionEvent onCollisonStary2D = new CollisionEvent();
    [SerializeField]
    private CollisionEvent onCollisonExit2D = new CollisionEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisonEnter2D.Invoke(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onCollisonStary2D.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollisonExit2D.Invoke(collision);
    }
    [Serializable]
    public class CollisionEvent : UnityEvent<Collision2D> { }
}
