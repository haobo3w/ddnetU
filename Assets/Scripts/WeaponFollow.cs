using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Transform PlayerPos;

    void Start()
    {
    }

    void Update()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerPos.position;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
       
        if (v.x < 0)
        {
            // Êó±êÔÚÈËÎï×ó²à£¬ ÎäÆ÷³¯×ó±ß·­×ª
            transform.localRotation = Quaternion.Euler(180, 0, -angle);
        }
        else
        {
            // Êó±êÔÚÈËÎïÓÒ²à£¬ ÎäÆ÷³¯ÓÒ±ß·­×ª
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
