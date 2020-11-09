using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSize : MonoBehaviour
{
    [SerializeField]
    EatableObjSO Player;

    void Start()
    {
        Debug.Log("Playerの大きさは" + Player.Size);
    }
}
