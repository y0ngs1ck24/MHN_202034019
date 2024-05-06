using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 patrolSize = new Vector2(10f, 10f);
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float detectionRange = 10f; // 시야 범위
    public string playerTag = "Player"; // 플레이어 태그
    public string wallTag = "Wall"; // 벽 태그

    private Vector3 targetPosition;
    private GameObject player; // 플레이어 오브젝트

    void Start()
    {
        SetRandomTargetPosition();
        player = GameObject.FindGameObjectWithTag(playerTag); // 플레이어 오브젝트 찾기
    }

    void Update()
    {
        // 플레이어가 시야 범위 내에 있는지 확인
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

        // 벽을 피해 이동
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, 1f) && hit.collider.CompareTag(wallTag))
        {
            // 벽과 충돌한 경우 재설정된 방향으로 이동
            SetRandomTargetPosition();
        }
        else
        {
            // 벽과 충돌하지 않으면 계속해서 목표 위치로 이동
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

        // 시야 범위 그리기
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
