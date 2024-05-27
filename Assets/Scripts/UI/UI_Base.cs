using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Diagnostics;
using Unity.VisualScripting;

/// <summary>
/// 모든 UI는 UI_Base 클래스를 상속받아야 한다.
/// </summary>
public class UI_Base : MonoBehaviour
{
    public static void BindEvent(GameObject _gameObject, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        // UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(go);
        UI_EventHandler evt = _gameObject.GetOrAddComponent<UI_EventHandler>();
        


    }

}
