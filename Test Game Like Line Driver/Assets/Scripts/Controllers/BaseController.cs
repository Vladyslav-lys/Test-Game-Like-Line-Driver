using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bases
{
    public class BaseController<TController> : MonoBehaviour where TController : MonoBehaviour
    {
        private static TController _instance;
        public static TController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TController>(); //Поиск объекта контроллера

                    //Если не находит происходит следующее...
                    if (_instance == null)
                    {
                        var gameObj = new GameObject(typeof(TController).ToString()); //Создание объекта
                        _instance = gameObj.AddComponent<TController>(); //Добавление скрипта в него и установка экземпляра
                        DontDestroyOnLoad(gameObj); //При перезагрузке сцены оставляем объект
                    }
                }
                return _instance;
            }
        }
    }
}
