using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testtttt : MonoBehaviour
{
    public GameObject g;
    private void Start()
    {
        Instantiate(g, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
