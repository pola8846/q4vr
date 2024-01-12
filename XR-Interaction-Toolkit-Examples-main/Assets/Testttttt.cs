using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testttttt : MonoBehaviour
{
    public List<ChessLayserCheck> objects;
    private void Start()
    {
        objects= new List<ChessLayserCheck>();

        ChessLayserCheck[] temp = GetComponentsInChildren<ChessLayserCheck>();
        foreach (ChessLayserCheck c in temp)
        {
            objects.Add(c);
        }
    }



}
