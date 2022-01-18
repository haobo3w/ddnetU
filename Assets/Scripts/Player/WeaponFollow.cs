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
            // �����������࣬ ��������߷�ת
            transform.localRotation = Quaternion.Euler(180, 0, -angle);
        }
        else
        {
            // ����������Ҳ࣬ �������ұ߷�ת
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
