using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLayserCheck : MonoBehaviour
{
    private int pointCount = 0;
    private bool Check = false;

    public void Point()
    {
        pointCount++;
        if (pointCount == 1)
        {
            Check = true;
            Debug.Log("Ȱ��ȭ");
        }
    }

    public void UnPoint()
    {
        pointCount--;
        if (pointCount == 0)
        {
            Check = false;
            Debug.Log("��Ȱ��ȭ");
        }
    }
}
