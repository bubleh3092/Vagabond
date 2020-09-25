using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCubes : MonoBehaviour
{
    public GameObject cubes;
    private Vector3 screenPoint, bias;
    private float y_lock;

    void Update()
    {
        if (cubes.transform.position.x > 0)
        {
            cubes.transform.position = Vector3.MoveTowards (cubes.transform.position, new Vector3(0f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);

        }
        else if ((cubes.transform.position.x < -8f))
        {
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(0f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
        }    
    }

    void OnMouseDown() //Выполняется при нажатии на экран.
    {
        y_lock = screenPoint.x; //Зафиксируем позицию экрана по y (0);
        bias = cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)); //Смещение кубов в глобальных координатах по нажатию на экран.
    }

    void OnMouseDrag() //Выполняется каждый кадр пока палец находится на экране и попадает по Collider.
    {
        Vector3 RealScreenLoc = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); //Возьмём координаты для смещения.
        Vector3 RealLoc = Camera.main.ScreenToWorldPoint(RealScreenLoc) + bias; //Складываем изначальные координаты и смещение, получаем новую позицию в RealLoc.
        RealLoc.y = screenPoint.y; //Чтобы "y" был равен 0, по "y" не двигаем
        cubes.transform.position = RealLoc; //Ставим кубы в установленную позицию.
    }
}
