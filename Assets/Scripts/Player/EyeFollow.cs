using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform PivotPoint;
    public Transform PlayerPos;

    private float rotateRadiusSquare;

    void Start()
    {
        rotateRadiusSquare = Mathf.Pow(Vector3.Distance(transform.position, PivotPoint.position), 2);
    }

    void Update()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerPos.position;
        var slope = v.y / v.x;
        var xSquare = rotateRadiusSquare / (1 + Mathf.Pow(slope, 2));
        var x = Mathf.Sqrt(xSquare);
        var y = Mathf.Sqrt(rotateRadiusSquare - xSquare);
        if (v.x < 0)
        {
            x = -x;
        }
        if (v.y < 0)
        {
            y = -y;
        }
        transform.localPosition = PivotPoint.localPosition + new Vector3(x, y);
    }
    
}
