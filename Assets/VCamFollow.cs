using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamFollow : MonoBehaviour
{
    [SerializeField]
    CinemachineTargetGroup TargetGroup;
    [SerializeField]
    float Radius = 4;

    public void AddCinemaChineGroup(Transform target)
    {
        TargetGroup.AddMember(target, 1, Radius);
    }
    public void RemoveCinemaChineGroup(Transform target)
    {
        TargetGroup.RemoveMember(target);
    }
}
