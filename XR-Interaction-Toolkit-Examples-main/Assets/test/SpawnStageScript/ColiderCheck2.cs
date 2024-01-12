using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderCheck2 : MonoBehaviour
{
        // private GameObject Target;

        public GameObject prefabToInstantiate;  // ������ ���ο� ������Ʈ�� ������
        private int numberOfDarkChessObjects = 0;

        void Start()
        {
            // ���� ���� �� Ư�� ������Ʈ�� ����
            SpawnNewObject();
        }

        void Update()
        {

        }

        // ������Ʈ�� �����ϰ� ���� �� ȣ���ϴ� �޼���
        void SpawnNewObject()
        {
            // ���ο� ������Ʈ�� ����
            GameObject StageN = Instantiate(prefabToInstantiate, new Vector3(0f, 0f, 0f), Quaternion.identity);

        }

        // OnTriggerEnter �̺�Ʈ�� �߻��� ������ ȣ��
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DarkChess"))
            {
                Debug.Log("���� ü�� ���� ����");

                // "DarkChess" �±׸� ���� ������Ʈ�� OnTriggerEnter�� ������ ������ ī��Ʈ ����
                numberOfDarkChessObjects++;

                if (numberOfDarkChessObjects >= 3)
                {
                    Debug.Log("���ÿ� �� �� �̻��� DarkChess ������Ʈ�� �浹");

                    // �� ���� ��� ���� ������Ʈ�� �迭�� ��������
                    GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

                    // �迭�� �ִ� ��� ������Ʈ�� ����
                    foreach (GameObject obj in allObjects)
                    {
                        Destroy(obj);
                    }

                    // �ٽ� ���ο� ������Ʈ ����
                    SpawnNewObject();

                    // numberOfDarkChessObjects ���� �ʱ�ȭ
                    numberOfDarkChessObjects = 0;
                }
            }
        }
    }
