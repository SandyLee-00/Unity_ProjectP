using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// path 가지고 바로 Instantiate 하기
/// </summary>
public class ResourceManager
{
    /*
        /// <summary>
        /// TODO : 리소스 불러올 때 타입별 경로 체크해줘서 리소스 이름만으로 불러오기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T Load<T>(string path) where T : Object
        {

        }*/

    /// <summary>
    /// 경로만 받아서 바로 프리팹 생성하기
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.LogError($"ResourceManager::Instantiate() failed. path={path}");
            return null;
        }
        return Instantiate(prefab, parent);
    }

    /// <summary>
    /// Instantiate 할 때 Clone 이름 제거하기
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject Instantiate(GameObject prefab, Transform parent = null)
    {
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    /// <summary>
    /// Destroy 할 때 Null 체크하고 LogError 남기기
    /// </summary>
    /// <param name="go"></param>
    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            Debug.LogError($"ResourceManager::Destroy() go is null");
            return;
        }
    }

}
