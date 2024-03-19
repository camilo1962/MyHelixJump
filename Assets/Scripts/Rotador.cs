using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public float rotacionVelocidad = 150.0f;

    void Update()
    {
        //if (!GameManager.isGameStarted)
        //    return;

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, - mouseX * rotacionVelocidad * Time.deltaTime, 0);
        }
        //// Para movil
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    float xDelta = Input.GetTouch(0).deltaPosition.x;
        //    transform.Rotate(0, -xDelta * rotacionVelocidad * Time.deltaTime, 0);
        //}
    }
}
