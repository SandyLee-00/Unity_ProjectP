using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 모든 매니저들을 관리하는 싱글톤 클래스
/// Sound / Game / Data
/// </summary>
public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    private static SoundManager s_soundManager = new SoundManager();
    private static GameManager s_gameManager = new GameManager();
    private static DataManager s_dataManager = new DataManager();



    public static SoundManager Sound { get { Init(); return s_soundManager; } }
    public static GameManager Game { get { Init(); return s_gameManager; } }
    public static DataManager Data { get { Init(); return s_dataManager; } }

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

            // 매니저 초기화
            s_soundManager.Init();
            s_dataManager.Init();

            Application.targetFrameRate = 60;
        }
    }
}
