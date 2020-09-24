using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public GameObject canvasUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Завершение уровня при взаемодействии финиша с игровым объектом
        if(collision.tag == "Player")
        {
            GameController.Instance.LevelCompleted(canvasUI);
        }
    }
}
 