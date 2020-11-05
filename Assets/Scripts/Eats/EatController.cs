using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var eatObj = collision.gameObject.GetComponent<EatableObjContoroller>();
        if (eatObj == null) return;

        //eatableObjController変更に伴って
        //  eatObj.Eaten();
    }
}
