using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType = Define.Scene.Unknown;

    protected bool alreadyInit = false;

    private void Start()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (alreadyInit)
        {
            return false;
        }

        alreadyInit = true;

        GameObject go = GameObject.Find("EventSystem");
        if (go == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem");
        }

        return true;
    }
    public virtual void Clear() { }
}
