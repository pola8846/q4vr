using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLayserCheck : MonoBehaviour
{
    public int pointCount = 0;

    public void Point()
    {
        pointCount++;
        if (pointCount == 1)
        {

        }
    }

    public void UnPoint()
    {
        pointCount--;
        if (pointCount == 0)
        {

        }
    }
}
