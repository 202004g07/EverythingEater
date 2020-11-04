using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    VCamFollow vCam;
    private void Awake()
    {
        vCam.AddCinemaChineGroup(transform);
    }

    private void OnDestroy()
    {
        vCam.RemoveCinemaChineGroup(transform);
    }
}
