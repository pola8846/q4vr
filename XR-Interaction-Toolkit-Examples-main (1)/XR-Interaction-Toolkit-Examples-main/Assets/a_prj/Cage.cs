using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    [SerializeField]
    private GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, g.transform.position.x - g.transform.localScale.x * 0.5f, g.transform.position.x + g.transform.localScale.x * 0.5f),
            Mathf.Clamp(transform.position.y, g.transform.position.y - g.transform.localScale.y * 0.5f, g.transform.position.y + g.transform.localScale.y * 0.5f),
            Mathf.Clamp(transform.position.z, g.transform.position.z - g.transform.localScale.z * 0.5f, g.transform.position.z + g.transform.localScale.z * 0.5f)
            );
    }
}
