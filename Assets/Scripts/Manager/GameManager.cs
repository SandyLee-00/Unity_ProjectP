using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 인게임 데이터를 저장하는 클래스
/// </summary>
[Serializable]
public class GameData
{
    public string PlayerName;
    public int Hp;
    public int MaxHp;
    public int Money;
}

/// <summary>
/// 실행되고 있는 게임에 대한 정보를 관리하는 클래스
/// </summary>
public class GameManager
{
    public void Init()
    {
    }

    #region 데이터 Save & Load	
    public GameData SaveData { get; set; }
    public string _path = Application.persistentDataPath + "/SaveData.json";

    /// <summary>
    /// 플레이 한 내용 저장하기
    /// </summary>
    public void SaveGame()
    {
        string jsonString = JsonUtility.ToJson(Managers.Game.SaveData);
        File.WriteAllText(_path, jsonString);
        Debug.Log("GameManager::SaveGame()");
    }

    /// <summary>
    /// Init 한 다음에 LoadGame을 호출하기
    /// SaveData.json에 저장된 데이터를 불러오기
    /// </summary>
    /// <returns></returns>
    public bool LoadGame()
    {
        if (File.Exists(_path) == false)
        {
            Debug.LogError("GameManager::LoadGame() File Not Found");
            return false;
        }

        string fileString = File.ReadAllText(_path);
        GameData data = JsonUtility.FromJson<GameData>(fileString);
        if (data == null)
        {
            Debug.LogError("GameManager::LoadGame() JsonUtility.FromJson<GameData> Failed");
            return false;
        }

        Managers.Game.SaveData = data;
        Debug.Log("GameManager::LoadGame()");
        return true;
    }
    #endregion
}
