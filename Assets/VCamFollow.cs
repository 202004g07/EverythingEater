using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamFollow : MonoBehaviour
{
    CinemachineVirtualCamera VCam;
    // Start is called before the first frame update
    void Start()
    {
        VCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Count() == 1) VCam.Follow = Player.BiggestPlayer;
    }
}
