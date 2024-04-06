using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarPillar : MonoBehaviour
{
    public Material materialToApply;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            //상단의 첫번째 가운데 삼각형
            new Vector3 (2.0f, 2.0f, 0.0f),
            new Vector3 (-2.0f, 2.0f, 0.0f),
            new Vector3 (0.0f, 2.0f, -1.0f),

            //상단의 두번째 왼쪽 삼각형
            new Vector3 (0.8f, 2.0f, -0.6f),
            new Vector3 (0.0f, 2.0f, 1.0f),
            new Vector3 (-1.5f, 2.0f, -2.0f),

            //상단의 세번째 오른쪽 삼각형
            new Vector3 (1.5f, 2.0f, -2.0f),
            new Vector3 (0.0f, 2.0f, 1.0f),
            new Vector3 (-0.8f, 2.0f, -0.6f),

            //하단의 첫번째 가운데 삼각형
            new Vector3 (2.0f, -2.0f, 0.0f),
            new Vector3 (-2.0f, -2.0f, 0.0f),
            new Vector3 (0.0f, -2.0f, -1.0f),
            
            //하단의 두번째 가운데 삼각형
            new Vector3 (0.8f, -2.0f, -0.6f),
            new Vector3 (0.0f, -2.0f, 1.0f),
            new Vector3 (-1.5f, -2.0f, -2.0f),
            
            //하단의 세번째 가운데 삼각형
            new Vector3 (1.5f, -2.0f, -2.0f),
            new Vector3 (0.0f, -2.0f, 1.0f),
            new Vector3 (-0.8f, -2.0f, -0.6f),

            //옆면 채우기
            new Vector3 (-2.0f, 2.0f, 0.0f),
            new Vector3 (-2.0f, -2.0f, 0.0f),
            new Vector3 (-0.8f, 2.0f, -0.6f),

            new Vector3 (-0.8f, 2.0f, -0.6f),
            new Vector3 (-2.0f, -2.0f, 0.0f),
            new Vector3 (-0.8f, -2.0f, -0.6f),

            new Vector3 (-0.8f, 2.0f, -0.6f),
            new Vector3 (-0.8f, -2.0f, -0.6f),
            new Vector3 (-1.5f, 2.0f, -2.0f),

            new Vector3 (-1.5f, 2.0f, -2.0f),
            new Vector3 (-0.8f, -2.0f, -0.6f),
            new Vector3 (-1.5f, -2.0f, -2.0f),

            new Vector3 (-1.5f, 2.0f, -2.0f),
            new Vector3 (-1.5f, -2.0f, -2.0f),
            new Vector3 (0.0f, 2.0f, -1.0f),

            new Vector3 (0.0f, 2.0f, -1.0f),
            new Vector3 (-1.5f, -2.0f, -2.0f),
            new Vector3 (0.0f, -2.0f, -1.0f),

            new Vector3 (0.0f, 2.0f, -1.0f),
            new Vector3 (0.0f, -2.0f, -1.0f),
            new Vector3 (1.5f, 2.0f, -2.0f),

            new Vector3 (1.5f, 2.0f, -2.0f),
            new Vector3 (0.0f, -2.0f, -1.0f),
            new Vector3 (1.5f, -2.0f, -2.0f),

            new Vector3 (1.5f, 2.0f, -2.0f),
            new Vector3 (1.5f, -2.0f, -2.0f),
            new Vector3 (0.8f, 2.0f, -0.6f),

            new Vector3 (0.8f, 2.0f, -0.6f),
            new Vector3 (1.5f, -2.0f, -2.0f),
            new Vector3 (0.8f, -2.0f, -0.6f),

            new Vector3 (0.8f, 2.0f, -0.6f),
            new Vector3 (0.8f, -2.0f, -0.6f),
            new Vector3 (2.0f, 2.0f, 0.0f),

            new Vector3 (2.0f, 2.0f, 0.0f),
            new Vector3 (0.8f, -2.0f, -0.6f),
            new Vector3 (2.0f, -2.0f, 0.0f),

            new Vector3 (2.0f, 2.0f, 0.0f),
            new Vector3 (2.0f, -2.0f, 0.0f),
            new Vector3 (0.5f, 2.0f, 0.0f),

            new Vector3 (0.5f, 2.0f, 0.0f),
            new Vector3 (2.0f, -2.0f, 0.0f),
            new Vector3 (0.5f, -2.0f, 0.0f),

            new Vector3 (0.5f, 2.0f, 0.0f),
            new Vector3 (0.5f, -2.0f, 0.0f),
            new Vector3 (0.0f, 2.0f, 1.0f),

            new Vector3 (0.0f, 2.0f, 1.0f),
            new Vector3 (0.5f, -2.0f, 0.0f),
            new Vector3 (0.0f, -2.0f, 1.0f),

            new Vector3 (0.0f, 2.0f, 1.0f),
            new Vector3 (0.0f, -2.0f, 1.0f),
            new Vector3 (-0.5f, 2.0f, 0.0f),

            new Vector3 (-0.5f, 2.0f, 0.0f),
            new Vector3 (0.0f, -2.0f, 1.0f),
            new Vector3 (-0.5f, -2.0f, 0.0f),

            new Vector3 (-0.5f, 2.0f, 0.0f),
            new Vector3 (-0.5f, -2.0f, 0.0f),
            new Vector3 (-2.0f, 2.0f, 0.0f),

            new Vector3 (-2.0f, 2.0f, 0.0f),
            new Vector3 (-0.5f, -2.0f, 0.0f),
            new Vector3 (-2.0f, -2.0f, 0.0f),
        };

        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            0, 2, 1, 
            3, 5, 4,
            6, 8, 7,
            
            9, 11, 10,
            12, 14, 13,
            15, 17, 16,

            18, 20, 19,
            21, 23, 22,

            24, 26, 25,
            27, 29, 28,

            30, 32, 31,
            33, 35, 34,

            36, 38, 37,
            39, 41, 40,

            42, 44, 43,
            45, 47, 46,

            48, 50, 49,
            51, 53, 52,

            54, 56, 55,
            57, 59, 58,

            60, 62, 61,
            63, 65, 64,

            66, 68, 67,
            69, 71, 70,

            72, 74, 73,
            75, 77, 76,
        };

        mesh.triangles = triangleIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;

        if (materialToApply != null)
        {
            mr.material = materialToApply;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
