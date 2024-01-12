using UnityEngine;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // 레이저
    private RaycastHit Collided_object; // 충돌된 객체
    private GameObject currentObject;   // 가장 최근에 충돌한 객체를 저장하기 위한 객체
    private ChessLayserCheck layserCheck;// 가장 최근에 충돌한 객체를 저장하기 위한 객체
    private ChessLayserCheck myLayserCheck;//내꺼
    public bool IsStarter = false; //최초 레이저인가?

    public GameObject parent;

    [SerializeField]
    private float raycastDistance = 8f; // 레이저 포인터 감지 거리

    // Start is called before the first frame update
    void Start()
    {
        // 스크립트가 포함된 객체에 라인 렌더러라는 컴포넌트를 넣고있다.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // 라인이 가지개될 색상 표현
        layser.material = IsStarter? GameManager.Material_lay_start : GameManager.Material_lay;
        // 레이저의 꼭지점은 2개가 필요 더 많이 넣으면 곡선도 표현 할 수 있다.
        layser.positionCount = 2;
        // 레이저 굵기 표현
        layser.startWidth = 0.3f;
        layser.endWidth = 0.01f;
        myLayserCheck = GetComponentInParent<ChessLayserCheck>();
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

            if (Collided_object.collider.gameObject.layer == LayerMask.NameToLayer("LayserTarget") &&//레이어가 타겟이면
                currentObject != Collided_object.collider.gameObject)
            {
                if (parent != null)
                {
                    if (Collided_object.collider.gameObject != parent)//자기가 아니라면
                    {
                        layserCheck?.UnPoint(this);

                        currentObject = Collided_object.collider.gameObject;//기억한다
                        layserCheck = currentObject.GetComponent<ChessLayserCheck>();
                        layserCheck?.Point(this, IsStarter ? 0 : myLayserCheck.Level);
                    }
                }
                else
                {
                    currentObject = Collided_object.collider.gameObject;//기억한다
                    layserCheck?.UnPoint(this);
                    layserCheck = currentObject.GetComponent<ChessLayserCheck>();
                    layserCheck?.Point(this, IsStarter ? 0 : myLayserCheck.Level);
                }
            }

            if (Collided_object.collider.gameObject.layer == LayerMask.NameToLayer("LayserBlocker"))//벽이라면
            {
                Unpoint();
            }
        }

        else
        {
            // 레이저에 감지된 것이 없기 때문에 레이저 초기 설정 길이만큼 길게 만든다.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            if (currentObject != null)
            {
                Unpoint();
            }

        }

    }

    public void Unpoint()
    {
        layserCheck?.UnPoint(this);
        layserCheck = null;
        currentObject = null;
    }
}