using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Respawn : MonoBehaviour
{
    [SerializeField]
    private GameObject g;

    private Vector3 origin;
    private Quaternion origin_q;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        origin_q = transform.rotation;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 sp = transform.position;
        Vector3 gpMin = g.transform.position - (g.transform.localScale / 2);
        Vector3 gpMax = g.transform.position + (g.transform.localScale / 2);
        if (sp.x < gpMin.x || sp.y < gpMin.y || sp.z < gpMin.z ||
            sp.x > gpMax.x || sp.y > gpMax.y || sp.z > gpMax.z)
        {
            transform.position = origin;
            transform.rotation = origin_q;
            rig.velocity = Vector3.zero;
        }
    }
}
