using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float waterLevel = .1f;

    public GameObject[] treePrefabs;
    public int height = 100;
    public int width = 30;
    public float scale = .1f;

    public Material terrainMaterial;
    public Material edgeMaterial;

    public float treeNoiseScale = .05f;
    public float treeDensity = .5f;

    Cell[,] grid;

    void Start() {
        float[,] noiseMap = new float[width, height];
        float xOffset = Random.Range(-2000f, 2000f);
        float yOffset = Random.Range(-5000f, 5000f);
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }

        float[,] falloffMap = new float[width, height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float xv = x / (float)width * 2 - 1;
                float yv = y / (float)height * 2 - 1;
                float v = Mathf.Max(Mathf.Abs(xv), Mathf.Abs(yv));
                falloffMap[x, y] = Mathf.Pow(v, 3f) / (Mathf.Pow(v, 3f) + Mathf.Pow(2.2f - 2.2f * v, 3f));
            }
        }

        grid = new Cell[width, height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Cell cell = new Cell();
                float noiseValue = noiseMap[x, y];
                noiseValue -= falloffMap[x, y];
                cell.isWater = noiseValue < waterLevel;
                grid[x, y] = cell;
            }
        }

        DrawTerrainMesh(grid);
        DrawTexture(grid);
        DrawEdgeMesh(grid);
        // GenerateTrees(grid);
    }

    void DrawEdgeMesh(Cell[,] grid) {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();

        List<int> triangles = new List<int>();
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Cell cell = grid[x, y];
                if (!cell.isWater) {
                    if (x > 0) {
                        Cell left = grid[x - 1, y];
                        if (left.isWater) {
                            Vector3 a = new Vector3(x - .5f, 0, y + .5f);
                            Vector3 b = new Vector3(x - .5f, 0, y - .5f);
                            Vector3 c = new Vector3(x - .5f, -1, y + .5f);
                            Vector3 d = new Vector3(x - .5f, -1, y - .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for (int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if (x < width - 1) {
                        Cell right = grid[x + 1, y];
                        if (right.isWater) {
                            Vector3 a = new Vector3(x + .5f, 0, y - .5f);
                            Vector3 b = new Vector3(x + .5f, 0, y + .5f);
                            Vector3 c = new Vector3(x + .5f, -1, y - .5f);
                            Vector3 d = new Vector3(x + .5f, -1, y + .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for (int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if (y > 0) {
                        Cell down = grid[x, y - 1];
                        if (down.isWater) {
                            Vector3 a = new Vector3(x - .5f, 0, y - .5f);
                            Vector3 b = new Vector3(x + .5f, 0, y - .5f);
                            Vector3 c = new Vector3(x - .5f, -1, y - .5f);
                            Vector3 d = new Vector3(x + .5f, -1, y - .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for (int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                    if (y < height - 1) {
                        Cell down = grid[x, y - 1];
                        if (down.isWater) {
                            Vector3 a = new Vector3(x + .5f, 0, y + .5f);
                            Vector3 b = new Vector3(x - .5f, 0, y + .5f);
                            Vector3 c = new Vector3(x + .5f, -1, y + .5f);
                            Vector3 d = new Vector3(x - .5f, -1, y + .5f);
                            Vector3[] v = new Vector3[] { a, b, c, b, d, c };
                            for (int k = 0; k < 6; k++) {
                                vertices.Add(v[k]);
                                triangles.Add(triangles.Count);
                            }
                        }
                    }
                }
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        GameObject edgeObj = new GameObject("Edge");
        edgeObj.transform.SetParent(transform);

        MeshFilter meshFilter = edgeObj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = edgeObj.AddComponent<MeshRenderer>();
        meshRenderer.material = edgeMaterial;
    }

    void DrawTerrainMesh(Cell[,] grid) {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Cell cell = grid[x, y];
                if (!cell.isWater) {
                    Vector3 a = new Vector3(x - .5f, 0, y + .5f);
                    Vector3 b = new Vector3(x + .5f, 0, y + .5f);
                    Vector3 c = new Vector3(x - .5f, 0, y - .5f);
                    Vector3 d = new Vector3(x + .5f, 0, y - .5f);
                    Vector3[] v = new Vector3[]{a, b, c, b, d, c};
                    for (int k = 0; k < 6; k++) {
                        vertices.Add(v[k]);
                        triangles.Add(triangles.Count);
                    }
                }
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
    }

    void DrawTexture(Cell[,] grid) {
        Texture2D texture = new Texture2D(width, height);
        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Cell cell = grid[x, y];
                if (cell.isWater) {
                    colorMap[y * width + x] = Color.blue;
                } else {
                    colorMap[y * width + x] = Color.green;
                }
            }
            texture.filterMode = FilterMode.Point;
            texture.SetPixels(colorMap);
            texture.Apply();

            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material = terrainMaterial;
            meshRenderer.material.mainTexture = texture;
        }
    }

    void GenerateTrees(Cell[,] grid) {
        float[,] noiseMap = new float[width, height];
        (float xOffset, float yOffset) = (Random.Range(-2000f, 2000f), Random.Range(-5000f, 5000f));

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float noiseValue = Mathf.PerlinNoise(x * treeNoiseScale, y * treeNoiseScale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Cell cell = grid[x, y];
                if (!cell.isWater) {
                    float v = Random.Range(0f, treeDensity);
                    if (noiseMap[x, y] < v) {
                        GameObject prefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
                        GameObject tree = Instantiate(prefab, transform);
                        tree.transform.position = new Vector3(x, 0, y);
                        tree.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
                        tree.transform.localScale = Vector3.one * Random.Range(.8f, 1.2f);
                    }
                }
            }
        }
    }

    void OnDrawGizmos() {
        if(!Application.isPlaying) return;

        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                Cell cell = grid[x, y];
                if (cell.isWater) {
                    Gizmos.color = Color.blue;
                } else {
                    Gizmos.color = Color.green;
                }
                Vector3 pos = new Vector3(x, 0, y);
                Gizmos.DrawCube(pos, Vector3.one);
            }
        }
    }
}
