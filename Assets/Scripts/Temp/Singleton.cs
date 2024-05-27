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
        // ��Ʈ ��������� ã��
        Transform root = transform;
        while (root.parent != null)
        {
            root = root.parent;
        }

        // ��Ʈ�� DontDestroyOnLoad ����
        DontDestroyOnLoad(root);
    }
}

public class AudioManager : Singleton<AudioManager>
{
    AudioSource BGMAudioSource;

    public override void Awake()
    {
        base.Awake();

        // AudioManager �ʱ�ȭ
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