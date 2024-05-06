using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 patrolSize = new Vector2(10f, 10f);
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float detectionRange = 10f; // �þ� ����
    public string playerTag = "Player"; // �÷��̾� �±�
    public string wallTag = "Wall"; // �� �±�

    private Vector3 targetPosition;
    private GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        SetRandomTargetPosition();
        player = GameObject.FindGameObjectWithTag(playerTag); // �÷��̾� ������Ʈ ã��
    }

    void Update()
    {
        // �÷��̾ �þ� ���� ���� �ִ��� Ȯ��
        if (player != null && Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            targetPosition = player.transform.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                SetRandomTargetPosition();
            }
        }

        // ���� ���� �̵�
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, 1f) && hit.collider.CompareTag(wallTag))
        {
            // ���� �浹�� ��� �缳���� �������� �̵�
            SetRandomTargetPosition();
        }
        else
        {
            // ���� �浹���� ������ ����ؼ� ��ǥ ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            RotateTowards(targetPosition);
        }
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-patrolSize.x / 2f, patrolSize.x / 2f);
        float randomZ = Random.Range(-patrolSize.y / 2f, patrolSize.y / 2f);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void RotateTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position;
        center.y = 0f;
        Gizmos.DrawWireCube(center, new Vector3(patrolSize.x, 0.1f, patrolSize.y));

        // �þ� ���� �׸���
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
