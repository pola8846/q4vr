using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLayserCheck : MonoBehaviour
{
    private int pointCount = 0;
    private bool check = false;
    public bool Check => check;

    public void Point()
    {
        pointCount++;
        if (pointCount == 1)
        {
            check = true;
            Debug.Log("Ȱ��ȭ");
        }
    }

    public void UnPoint()
    {
        pointCount--;
        if (pointCount == 0)
        {
            check = false;
            Debug.Log("��Ȱ��ȭ");
        }
    }
}
