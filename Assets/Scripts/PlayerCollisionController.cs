using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D MouseCollision;
    private void Awake()
    {
        MouseCollision.enabled = false;
    }
    public void OnDetectEatableObj(Collision2D collider)
    {
        var hitObj = collider.gameObject.GetComponent<IEatable>();

        if (!hitObj.IsEatable() || hitObj == null)
        {
            Debug.Log("Cant Eat");
            return;
        }

        MouseCollision.enabled = true;
    }
    public void OnEatableObjExit(Collision2D collider)
    {
        MouseCollision.enabled = false;
    }
}
