using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // ������
    private RaycastHit Collided_object; // �浹�� ��ü
    private GameObject currentObject;   // ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü

    public float raycastDistance = 100f; // ������ ������ ���� �Ÿ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ�� ���Ե� ��ü�� ���� ��������� ������Ʈ�� �ְ��ִ�.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // ������ �������� ���� ǥ��
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 255, 0.5f);
        layser.material = material;
        // �������� �������� 2���� �ʿ� �� ���� ������ ��� ǥ�� �� �� �ִ�.
        layser.positionCount = 2;
        // ������ ���� ǥ��
        layser.startWidth = 0.3f;
        layser.endWidth = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        layser.SetPosition(0, transform.position); // ù��° ������ ��ġ
                                                   // ������Ʈ�� �־� �����ν�, �÷��̾ �̵��ϸ� �̵��� ���󰡰� �ȴ�.
                                                   //  �� �����(�浹 ������ ����)
                                                   //Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // �浹 ���� ��
        int layerMask = 1 << LayerMask.NameToLayer("LaserTarget");
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance, layerMask))
        {
            Debug.Log(1);
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.CompareTag("Test"))
            {
                // ��ŧ���� �� �����ܿ� ū ���׶�� �κ��� ���� ���
                if (Input.GetMouseButtonDown(0))
                {
                    // ��ư�� ��ϵ� onClick �޼ҵ带 �����Ѵ�.
                    //Collided_object.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                else
                {
                    //Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentObject = Collided_object.collider.gameObject;
                }
            }
        }

        else
        {
            // �������� ������ ���� ���� ������ ������ �ʱ� ���� ���̸�ŭ ��� �����.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // �ֱ� ������ ������Ʈ�� Button�� ���
            // ��ư�� ���� �����ִ� �����̹Ƿ� �̰��� Ǯ���ش�.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }

        }

    }

    private void LateUpdate()
    {
        // ��ư�� ���� ���        
        if (Input.GetMouseButtonDown(0))
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);
        }

        // ��ư�� �� ���          
        else if (Input.GetMouseButtonUp(0))
        {
            layser.material.color = new Color(0, 195, 255, 0.5f);
        }
    }
}