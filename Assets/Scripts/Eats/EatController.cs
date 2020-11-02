using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!collision.gameObject.CompareTag("Eatable")) return;

        var eatObj = collision.gameObject.GetComponent<EatableObjContoroller>();
        if (eatObj == null) return;

        eatObj.Eaten();
    }
}
