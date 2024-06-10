using UnityEngine;

public class PlayScene : BaseScene
{
    protected override bool Init()
    {
        if(base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.Play;

        // 씬 시작할 때 생성할 게임 오브젝트

        Debug.Log("PlayScene::Init()");
        return true;
    }
}