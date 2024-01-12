using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderCheck2 : MonoBehaviour
{
        // private GameObject Target;

        public GameObject prefabToInstantiate;  // 생성할 새로운 오브젝트의 프리팹
        private int numberOfDarkChessObjects = 0;

        void Start()
        {
            // 게임 시작 시 특정 오브젝트를 생성
            SpawnNewObject();
        }

        void Update()
        {

        }

        // 오브젝트를 생성하고 싶을 때 호출하는 메서드
        void SpawnNewObject()
        {
            // 새로운 오브젝트를 생성
            GameObject StageN = Instantiate(prefabToInstantiate, new Vector3(0f, 0f, 0f), Quaternion.identity);

        }

        // OnTriggerEnter 이벤트가 발생할 때마다 호출
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DarkChess"))
            {
                Debug.Log("검은 체스 말과 접촉");

                // "DarkChess" 태그를 가진 오브젝트가 OnTriggerEnter에 진입할 때마다 카운트 증가
                numberOfDarkChessObjects++;

                if (numberOfDarkChessObjects >= 3)
                {
                    Debug.Log("동시에 세 개 이상의 DarkChess 오브젝트와 충돌");

                    // 씬 내의 모든 게임 오브젝트를 배열로 가져오기
                    GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

                    // 배열에 있는 모든 오브젝트를 삭제
                    foreach (GameObject obj in allObjects)
                    {
                        Destroy(obj);
                    }

                    // 다시 새로운 오브젝트 생성
                    SpawnNewObject();

                    // numberOfDarkChessObjects 변수 초기화
                    numberOfDarkChessObjects = 0;
                }
            }
        }
    }
