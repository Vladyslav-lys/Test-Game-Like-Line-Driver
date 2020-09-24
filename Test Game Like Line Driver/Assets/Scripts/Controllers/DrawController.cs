using Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : BaseController<DrawController>
{
    public GameObject lineObject;
    private GameObject currentLine;
    private Camera camera;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> touchPostitions;
    private bool isDrawn;

    private void Start()
    {
        isDrawn = false;
        camera = Camera.main;
        touchPostitions = new List<Vector2>();
    }

    private void Update()
    {
        //Условие для одноразового рисования
        if (IsDrawn())
            return;

        Vector3 touchPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            CreateLine(touchPoint); //Создание линии
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            //Дистанция между точками не менее 0.5
            if (DistanceBetweenCurrentAndLastPointOnLine(touchPoint, 0.5f))
            {
                UpdateLine(touchPoint); //Обновить линию
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
        {
            SetDrawn(); //Установка объекта как нарисованого
        }
    }

    private void CreateLine(Vector3 touchPoint)
    {
        currentLine = Instantiate<GameObject>(lineObject, touchPoint, Quaternion.identity); //Создание линии из префаба
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        edgeCollider.offset = new Vector2(3.4f, -0.6f); //Сдвиг коллайдера, чтобы он соответствовал позиции линии

        touchPostitions.Clear(); //Очищение массива позиций
        touchPostitions.Add(camera.ScreenToWorldPoint(Input.mousePosition)); //Первая точка
        touchPostitions.Add(camera.ScreenToWorldPoint(Input.mousePosition)); //Вторая точка
        lineRenderer.SetPosition(0, touchPostitions[0]); //Установка первой точки
        lineRenderer.SetPosition(1, touchPostitions[1]); //Установка второй точки
        edgeCollider.points = touchPostitions.ToArray(); //Присвоение коллайдеру точек соответствующей линии
    }

    private void UpdateLine(Vector2 newTouchPosition)
    {
        touchPostitions.Add(newTouchPosition); //Добавление новой конечной точки
        lineRenderer.positionCount++; //Увеличение ёмкости массива
        int indexOfLastElement = lineRenderer.positionCount - 1; //Выбор индекса последнего элемента элемента
        lineRenderer.SetPosition(indexOfLastElement, touchPostitions[indexOfLastElement]); //Установка новой конечной точки
        edgeCollider.points = touchPostitions.ToArray(); //Присвоение коллайдеру точек соответствующей линии
    }

    private bool DistanceBetweenCurrentAndLastPointOnLine(Vector2 touchPoint, float minDistance)
    {
        return Vector2.Distance(touchPoint, touchPostitions[touchPostitions.Count - 1]) > minDistance;
    }

    public bool IsDrawn()
    {
        return this.isDrawn;
    }

    public void SetDrawn()
    {
        this.isDrawn = true;
    }
}