using Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : BaseController<SceneController>
{
    //Загружает одиночную сцену sceneName
    public void LoadSingleScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadSingleGameScene()
    {
        this.LoadSingleScene("Game Scene");
    }

    public void LoadSingleStartScene()
    {
        this.LoadSingleScene("Start Scene");
    }

    //Загружает дополнительную сцену sceneName
    public void LoadAdditiveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void LoadAdditiveGameScene()
    {
        this.LoadAdditiveScene("Game Scene");
    }

    public void LoadAdditiveStartScene()
    {
        this.LoadAdditiveScene("Start Scene");
    }
}
