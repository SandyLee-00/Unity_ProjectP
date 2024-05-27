using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Diagnostics;
using Unity.VisualScripting;

/// <summary>
/// ��� UI�� UI_Base Ŭ������ ��ӹ޾ƾ� �Ѵ�.
/// </summary>
public class UI_Base : MonoBehaviour
{
    public static void BindEvent(GameObject _gameObject, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        // UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(go);
        UI_EventHandler evt = _gameObject.GetOrAddComponent<UI_EventHandler>();
        


    }

}
