using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private GameObject g;
    
    private float scale;
    private Vector3 origin;
    private Vector3 origin_g;

    void Start()
    {
        origin = transform.position;
        origin_g = g.transform.position;
        scale =  transform.localScale.magnitude / g.transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin + ((g.transform.position - origin_g) * scale);
        transform.rotation = g.transform.rotation;
    }
}
