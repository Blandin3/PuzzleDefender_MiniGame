using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 8;
    public int height = 8;
    public float cellSize = 1.5f;

    public GameObject tilePrefab;

    public static GridManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    public Vector2 GetTopEdge()    => new Vector2(0,  (height - 1) * cellSize / 2f);
    public Vector2 GetBottomEdge() => new Vector2(0, -((height - 1) * cellSize / 2f));
    public Vector2 GetCenter()     => Vector2.zero;
    public Vector2 GetLeftEdge()   => new Vector2(-((width - 1) * cellSize / 2f), 0);
    public Vector2 GetRightEdge()  => new Vector2(  (width - 1) * cellSize / 2f,  0);

    void GenerateGrid()
    {
        float offsetX = (width - 1) * cellSize / 2f;
        float offsetY = (height - 1) * cellSize / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(x * cellSize - offsetX, y * cellSize - offsetY);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.transform.localScale = Vector3.one * (cellSize * 0.85f);
                SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
                sr.color = new Color(0.75f, 0.75f, 0.75f);
                sr.sortingOrder = 0;
            }
        }
    }
}
