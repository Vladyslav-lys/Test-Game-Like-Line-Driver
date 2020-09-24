using Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : BaseController<GameController>
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    //Успешное завершение уровня
    public void LevelCompleted(GameObject objectUI)
    {
        this.StopTime();
        this.OpenUI(objectUI);
    }

    //Ставит игру на паузу
    public void PauseGame(GameObject objectUI)
    {
        this.OpenUI(objectUI);
    }

    //Останавливает время
    public void StopTime()
    {
        Time.timeScale = 0;
    }

    //Открытие UI
    public void OpenUI(GameObject objectUI)
    {
        objectUI.SetActive(true);
    }
}
