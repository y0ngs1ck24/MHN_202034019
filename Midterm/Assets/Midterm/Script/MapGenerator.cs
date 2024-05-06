using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab; // 타일 프리팹
    [SerializeField] Transform parentTransform; // 타일들을 담을 부모 트랜스폼
    [SerializeField] GameObject lowWallPrefab;
    [SerializeField] GameObject highWallPrefab;

    private int[,] mapData; // 맵 데이터를 저장할 2차원 배열

    void Start()
    {
        // CSV 파일 경로 설정
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "map.csv");

        // CSV 파일에서 맵 데이터 로드
        LoadMapDataFromCSV(filePath);

        // 맵 생성
        GenerateMap();
    }

    // CSV 파일에서 맵 데이터 로드
    public void LoadMapDataFromCSV(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int width = lines[0].Split(',').Length;
            int height = lines.Length;
            mapData = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                string[] entries = lines[y].Split(',');
                for (int x = 0; x < width; x++)
                {
                    mapData[x, y] = int.Parse(entries[x]);
                }
            }
        }
        else
        {
            Debug.LogWarning("File not found: " + filePath);
        }
    }

    // 맵 생성
    public void GenerateMap()
    {
        if (mapData == null)
        {
            Debug.LogError("Map data is not loaded.");
            return;
        }

        // Parent Transform의 스케일 값 가져오기
        Vector3 parentScale = parentTransform.localScale;

        // 타일들 생성
        for (int y = 0; y < mapData.GetLength(1); y++)
        {
            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                // 타일의 위치 계산
                Vector3 tilePosition = new Vector3(x * parentScale.x, 0, y * parentScale.z);

                // 타일 생성
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, parentTransform);

                switch (mapData[x, y])
                {
                    case 1:
                        // 낮은 벽 생성
                        Vector3 lowWallPosition = tilePosition + Vector3.up * 0.5f; // 타일 위치에서 상대적인 위치에 벽 생성
                        GameObject lowWall = Instantiate(lowWallPrefab, lowWallPosition, Quaternion.identity, parentTransform);
                        break;
                    case 2:
                        // 높은 벽 생성
                        Vector3 highWallPosition = tilePosition + Vector3.up * 0.5f; // 타일 위치에서 상대적인 위치에 벽 생성
                        GameObject highWall = Instantiate(highWallPrefab, highWallPosition, Quaternion.identity, parentTransform);
                        break;
                }
            }
        }
    }
}
