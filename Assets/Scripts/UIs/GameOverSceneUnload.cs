using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneUnload : MonoBehaviour
{
    private void OnDestroy()
    {
        GameDirector.Instance.DestroySelf();
    }
}
