using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    GameObject _gameObject = new GameObject("@" + typeof(T).Name);
                    instance = _gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        // 루트 재귀적으로 찾기
        Transform root = transform;
        while (root.parent != null)
        {
            root = root.parent;
        }

        // 루트에 DontDestroyOnLoad 적용
        DontDestroyOnLoad(root);
    }
}

public class AudioManager : Singleton<AudioManager>
{
    AudioSource BGMAudioSource;

    public override void Awake()
    {
        base.Awake();

        // AudioManager 초기화
        GameObject BGM = new GameObject("BGM");
        BGM.transform.SetParent(transform);
        BGMAudioSource = BGM.AddComponent<AudioSource>();
    }

    public bool Play(Define.Sound type = 0, string path = "", float volume = 1.0f, float pitch = 1.0f)
    {
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip == null)
        {
            Debug.Log($"AudioManager::Play() AudioClip is null. path: {path}");
            return false;
        }
        if (type == 0)
        {
            BGMAudioSource.clip = clip;
            BGMAudioSource.volume = volume;
            BGMAudioSource.pitch = pitch;
            BGMAudioSource.Play();
            return true;
        }

        return false;
    }
}