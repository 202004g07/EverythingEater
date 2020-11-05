using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEatenView : MonoBehaviour
{
    [SerializeField]
    Image image;
    [SerializeField]
    Text Name;
    Color DefaultColor;
    private void Awake()
    {
        DefaultColor = image.color;
        Name.text = "";
        image.color = Color.clear;
    }

    public void View(EatableObjSO objSO)
    {
        image.color = DefaultColor;

        image.sprite = objSO.m_Sprite;
        Name.text = objSO.Name;
    }
}
