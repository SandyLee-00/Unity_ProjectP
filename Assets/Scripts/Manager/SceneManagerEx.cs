using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    private Define.Scene currentSceneType = Define.Scene.Unknown;

    public Define.Scene CurrentSceneType
    {
        get
        {
            if (currentSceneType != Define.Scene.Unknown)
            {
                return currentSceneType;
            }
            return CurrentSceneComponent.SceneType;
        }
        set { currentSceneType = value; }
    }

    public BaseScene CurrentSceneComponent { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        CurrentSceneComponent.Clear();

        currentSceneType = type;
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }
}
