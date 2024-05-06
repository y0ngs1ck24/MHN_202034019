using UnityEngine;
using System.Collections;
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationDuration = 1f;
    public GameObject startPoint; // �÷��̾��� ���� ��ġ�� ������ ���� ������Ʈ
    public GameObject endpoint; // �÷��̾ �����ؾ� �� ��ǥ ����
    public TMP_Text displayText; // TMP �ؽ�Ʈ ������Ʈ

    private Camera mainCamera;
    private GameObject plane;

    private bool isRotating = false;
    private bool hasReachedEndpoint = false; // endpoint�� �����ߴ��� ���θ� ��Ÿ���� �÷���

    void Start()
    {
        mainCamera = Camera.main;
        plane = GameObject.Find("Terrain");

        if (startPoint != null)
        {
            Vector3 startPosition = startPoint.transform.position;
            startPosition.y += 1f; // y�� ���� 1�� ���մϴ�.
            transform.position = startPosition;
        }

        // TMP �ؽ�Ʈ�� ã���ϴ�.
        if (displayText == null)
        {
            // TMP �ؽ�Ʈ�� �������� ���� ���, �÷��̾��� �ڽ����� �ִ� TMP �ؽ�Ʈ�� ã���ϴ�.
            displayText = GetComponentInChildren<TMP_Text>();
        }
    }

    void Update()
    {
        if (!hasReachedEndpoint)
        {
            PlayerMoving();
            if (!isRotating) // ȸ�� ���� �ƴ� ��쿡�� ī�޶� ȸ���� ó��
                StartCoroutine(CameraMoving());

            // �÷��̾ endpoint�� �����ϸ� TMP �ؽ�Ʈ�� �����ϰ� �÷��׸� �����մϴ�.
            if (endpoint != null && Vector3.Distance(transform.position, endpoint.transform.position) < 0.1f)
            {
                if (displayText != null)
                {
                    displayText.text = "Clear"; // TMP �ؽ�Ʈ�� "Clear"�� �����մϴ�.
                }
                hasReachedEndpoint = true; // endpoint�� ������ ���·� �÷��׸� �����մϴ�.
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
