using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBg;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginPos;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginPos = joystickBg.transform.position;
        joystickRadius = joystickBg.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBg.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        Debug.Log(joystickTouchPos);
    }

    public void Drag(BaseEventData b)
    {
        PointerEventData p = b as PointerEventData;
        Vector2 dragPos = p.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDis = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDis < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDis;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginPos;
        joystickBg.transform.position = joystickOriginPos;
    }
}
