using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // 레이저
    private RaycastHit Collided_object; // 충돌된 객체
    private GameObject currentObject;   // 가장 최근에 충돌한 객체를 저장하기 위한 객체
    private ChessLayserCheck layserCheck;

    public float raycastDistance = 100f; // 레이저 포인터 감지 거리
    public Material material1;

    // Start is called before the first frame update
    void Start()
    {
        // 스크립트가 포함된 객체에 라인 렌더러라는 컴포넌트를 넣고있다.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // 라인이 가지개될 색상 표현
        layser.material = material1;
        // 레이저의 꼭지점은 2개가 필요 더 많이 넣으면 곡선도 표현 할 수 있다.
        layser.positionCount = 2;
        // 레이저 굵기 표현
        layser.startWidth = 0.3f;
        layser.endWidth = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        layser.SetPosition(0, transform.position); // 첫번째 시작점 위치
                                                   // 업데이트에 넣어 줌으로써, 플레이어가 이동하면 이동을 따라가게 된다.
                                                   //  선 만들기(충돌 감지를 위한)
                                                   //Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // 충돌 감지 시
        int layerMask = (1 << LayerMask.NameToLayer("LayserTarget")) + (1 << LayerMask.NameToLayer("LayserBlocker"));
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance, layerMask))
        {
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.layer == LayerMask.NameToLayer("LayserTarget"))
            {
                if (currentObject!= Collided_object.collider.gameObject)
                {
                    currentObject = Collided_object.collider.gameObject;
                    layserCheck = currentObject.GetComponent<ChessLayserCheck>();
                    layserCheck.Point();
                }
            }

            if (Collided_object.collider.gameObject.CompareTag("Test"))
            {
                {
                    //Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                }
            }
        }

        else
        {
            // 레이저에 감지된 것이 없기 때문에 레이저 초기 설정 길이만큼 길게 만든다.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            if (currentObject != null)
            {
                //currentObject.GetComponent<Button>()?.OnPointerExit(null);
                layserCheck.UnPoint();
                layserCheck = null;
                currentObject = null;
            }

        }

    }
}