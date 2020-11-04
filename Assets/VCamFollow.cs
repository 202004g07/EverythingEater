using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamFollow : MonoBehaviour
{
    CinemachineVirtualCamera VCam;

    [SerializeField]
    CinemachineTargetGroup TargetGroup;
    [SerializeField]
    float Radius = 4;
    // Start is called before the first frame update
    void Start()
    {
        VCam = GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        // if (Player.Count() == 1) VCam.Follow = Player.BiggestPlayer;
    }
    public void AddCinemaChineGroup(Transform target)
    {
        TargetGroup.AddMember(target, 1, Radius);
    }
    public void RemoveCinemaChineGroup(Transform target)
    {
        TargetGroup.RemoveMember(target);
    }
}
