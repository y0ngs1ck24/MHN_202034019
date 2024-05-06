using UnityEngine;
using System.Collections;
using TMPro; // TextMeshPro 네임스페이스 추가

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationDuration = 1f;
    public GameObject startPoint; // 플레이어의 시작 위치를 설정할 게임 오브젝트
    public GameObject endpoint; // 플레이어가 도달해야 할 목표 지점
    public TMP_Text displayText; // TMP 텍스트 컴포넌트

    private Camera mainCamera;
    private GameObject plane;

    private bool isRotating = false;
    private bool hasReachedEndpoint = false; // endpoint에 도달했는지 여부를 나타내는 플래그

    void Start()
    {
        mainCamera = Camera.main;
        plane = GameObject.Find("Terrain");

        if (startPoint != null)
        {
            Vector3 startPosition = startPoint.transform.position;
            startPosition.y += 1f; // y축 값에 1을 더합니다.
            transform.position = startPosition;
        }

        // TMP 텍스트를 찾습니다.
        if (displayText == null)
        {
            // TMP 텍스트가 지정되지 않은 경우, 플레이어의 자식으로 있는 TMP 텍스트를 찾습니다.
            displayText = GetComponentInChildren<TMP_Text>();
        }
    }

    void Update()
    {
        if (!hasReachedEndpoint)
        {
            PlayerMoving();
            if (!isRotating) // 회전 중이 아닌 경우에만 카메라 회전을 처리
                StartCoroutine(CameraMoving());

            // 플레이어가 endpoint에 도달하면 TMP 텍스트를 변경하고 플래그를 설정합니다.
            if (endpoint != null && Vector3.Distance(transform.position, endpoint.transform.position) < 0.1f)
            {
                if (displayText != null)
                {
                    displayText.text = "Clear"; // TMP 텍스트를 "Clear"로 변경합니다.
                }
                hasReachedEndpoint = true; // endpoint에 도달한 상태로 플래그를 설정합니다.
            }
        }
    }

    void PlayerMoving()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= mainCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += mainCamera.transform.right;
        }

        moveDirection.y = 0f;
        moveDirection = transform.TransformDirection(moveDirection);
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    IEnumerator CameraMoving()
    {
        isRotating = true;

        Vector3 planeSize = plane.transform.localScale;

        if (Input.GetKeyDown(KeyCode.O))
        {
            Quaternion targetRotation = Quaternion.AngleAxis(90f, Vector3.up);
            Quaternion startRotation = mainCamera.transform.rotation;
            float elapsedTime = 0f;

            while (elapsedTime < rotationDuration)
            {
                mainCamera.transform.RotateAround(plane.transform.position, Vector3.up, 90f * Time.deltaTime / rotationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            mainCamera.transform.rotation = targetRotation;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Quaternion targetRotation = Quaternion.AngleAxis(-90f, Vector3.up);
            Quaternion startRotation = mainCamera.transform.rotation;
            float elapsedTime = 0f;

            while (elapsedTime < rotationDuration)
            {
                mainCamera.transform.RotateAround(plane.transform.position, Vector3.up, -90f * Time.deltaTime / rotationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            mainCamera.transform.rotation = targetRotation;
        }

        mainCamera.transform.LookAt(plane.transform.position);

        isRotating = false;
    }
}
