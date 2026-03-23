using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject fastEnemyPrefab;
    public GameObject tankEnemyPrefab;

    private Transform spawnPoint;
    private Transform goal;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        goal = GameObject.Find("Goal").transform;

        // place them on opposite sides of the grid
        float half = (GridManager.Instance.width - 1) * GridManager.Instance.cellSize / 2f;
        spawnPoint.position = new Vector2(-half, 0);
        goal.position = new Vector2(half, 0);
        goal.gameObject.tag = "Target";

        SpriteRenderer goalSr = goal.GetComponent<SpriteRenderer>();
        if (goalSr != null)
        {
            goalSr.color = Color.green;
            goalSr.sortingOrder = 1;
        }

        SpawnEnemy("fast");
        InvokeRepeating(nameof(SpawnNext), 5f, 4f);
    }

    private int spawnCount = 0;
    private int totalWaves = 10;
    private int enemiesAlive = 0;

    void SpawnNext()
    {
        if (GameManager.Instance.lives <= 0) return;

        if (spawnCount >= totalWaves)
        {
            CancelInvoke(nameof(SpawnNext));
            return;
        }

        string type = (spawnCount % 3 == 0) ? "tank" : "fast";
        SpawnEnemy(type);
        spawnCount++;
    }

    public void EnemyRemoved()
    {
        enemiesAlive--;
        if (spawnCount >= totalWaves)
            GameManager.Instance.CheckWinCondition(enemiesAlive);
    }

    public void SpawnEnemy(string type)
    {
        GameObject enemy = null;

        if (type == "fast")
            enemy = Instantiate(fastEnemyPrefab, spawnPoint.position, Quaternion.identity);
        else if (type == "tank")
            enemy = Instantiate(tankEnemyPrefab, spawnPoint.position, Quaternion.identity);

        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().target = goal;
            enemiesAlive++;
        }
    }
}
