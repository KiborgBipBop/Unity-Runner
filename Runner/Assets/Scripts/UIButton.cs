using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public string buttonName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonName == "start")
        {
            Loader.LoadOnAction("StartButtonPressed");
        }
        else if (buttonName == "exit")
        {
            Application.Quit();
        }
    }
}
