using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    EatableObjSO PlayerSO;

    void Update()
    {
        PlayerSO.Size = Player.BiggestSize;
    }
}
