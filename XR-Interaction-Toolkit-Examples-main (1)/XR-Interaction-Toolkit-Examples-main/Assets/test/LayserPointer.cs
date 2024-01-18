using UnityEngine;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // ������
    private RaycastHit Collided_object; // �浹�� ��ü
    private GameObject currentObject;   // ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü
    private ChessLayserCheck layserCheck;// ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü
    private ChessLayserCheck myLayserCheck;//����
    public bool IsStarter = false; //���� �������ΰ�?

    public GameObject parent;

    [SerializeField]
    private float raycastDistance = 8f; // ������ ������ ���� �Ÿ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ�� ���Ե� ��ü�� ���� ��������� ������Ʈ�� �ְ��ִ�.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // ������ �������� ���� ǥ��
        layser.material = IsStarter? GameManager.Material_lay_start : GameManager.Material_lay;
        // �������� �������� 2���� �ʿ� �� ���� ������ ��� ǥ�� �� �� �ִ�.
        layser.positionCount = 2;
        // ������ ���� ǥ��
        layser.startWidth = 0.3f;
        layser.endWidth = 0.01f;
        myLayserCheck = GetComponentInParent<ChessLayserCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        layser.SetPosition(0, transform.position); // ù��° ������ ��ġ
                                                   // ������Ʈ�� �־� �����ν�, �÷��̾ �̵��ϸ� �̵��� ���󰡰� �ȴ�.
                                                   //  �� �����(�浹 ������ ����)
                                                   //Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // �浹 ���� ��
        int layerMask = (1 << LayerMask.NameToLayer("LayserTarget")) + (1 << LayerMask.NameToLayer("LayserBlocker"));
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance, layerMask))
        {
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.layer == LayerMask.NameToLayer("LayserTarget") &&//���̾ Ÿ���̸�
                currentObject != Collided_object.collider.gameObject)
            {
                if (parent != null)
                {
                    if (Collided_object.collider.gameObject != parent)//�ڱⰡ �ƴ϶��
                    {
                        layserCheck?.UnPoint(this);

                        currentObject = Collided_object.collider.gameObject;//����Ѵ�
                        layserCheck = currentObject.GetComponent<ChessLayserCheck>();
                        layserCheck?.Point(this, IsStarter ? 0 : myLayserCheck.Level);
                    }
                }
                else
                {
                    currentObject = Collided_object.collider.gameObject;//����Ѵ�
                    layserCheck?.UnPoint(this);
                    layserCheck = currentObject.GetComponent<ChessLayserCheck>();
                    layserCheck?.Point(this, IsStarter ? 0 : myLayserCheck.Level);
                }
            }

            if (Collided_object.collider.gameObject.layer == LayerMask.NameToLayer("LayserBlocker"))//���̶��
            {
                Unpoint();
            }
        }

        else
        {
            // �������� ������ ���� ���� ������ ������ �ʱ� ���� ���̸�ŭ ��� �����.
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