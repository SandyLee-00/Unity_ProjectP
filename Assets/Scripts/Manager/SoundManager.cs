using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 사운드 매니저
/// </summary>  
public class SoundManager
{
    private GameObject _soundRoot = null;

    public void Init()
    {
        if (_soundRoot == null)
        {
            _soundRoot = GameObject.Find("@SoundRoot");

            if (_soundRoot == null)
            {
                _soundRoot = new GameObject { name = "@SoundRoot" };
                DontDestroyOnLoad(_soundRoot);

                string[] soundTypeNames = System.Enum.GetNames(typeof(Define.Sound));
            }
        }
    }
}
