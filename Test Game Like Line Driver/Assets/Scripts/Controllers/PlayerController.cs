using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent RestartEvent;
    public Vector2 force;
    public float minYToFall; //Значение Y, при котором объект считается упавшим
    private Rigidbody2D playerRigidbody2D;
    private Transform playerTransform;
    private DrawController drawController;

    private void Start()
    {
        drawController = DrawController.Instance;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody2D.simulated = false; //Отключение симуляции движения объекта при старте сцены
    }

    private void FixedUpdate()
    {
        //Проверка на нарисованный объект
        if (!drawController.IsDrawn())
        {
            return;
        } 
        else //Если нарисованный, запускаем велосипед
        {
            playerRigidbody2D.simulated = true;
            playerRigidbody2D.AddForce(force);
        }
    }

    private void Update()
    {
        //Проверка на падение объекта
        if (!IsFallen())
            return;

        //Если упал, выполняем рестарт уровня
        RestartEvent?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Остановка объекта при достижения финиша
        if(collision.tag == "Finish")
        {
            playerRigidbody2D.simulated = false;
        }
    }

    private bool IsFallen()
    {
        return this.playerTransform.position.y < this.minYToFall;
    }
}
