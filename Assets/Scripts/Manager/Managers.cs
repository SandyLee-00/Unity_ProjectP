using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 모든 매니저들을 관리하는 싱글톤 클래스
/// </summary>
public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    private static SoundManager s_soundManager = new SoundManager();

    public static SoundManager Sound { get { Init(); return s_soundManager; } }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
            }

            s_instance = go.GetOrAddComponent<Managers>();
            DontDestroyOnLoad(go);

            s_soundManager.Init();

            Application.targetFrameRate = 60;
        }
    }
}
