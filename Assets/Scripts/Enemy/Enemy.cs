using UnityEngine;

public class Enemy : Character
{
    public Transform target;

    private IEnemyState currentState = new MoveState();
    protected Color originalColor;

    protected virtual void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        sr.sortingOrder = 2;
        originalColor = sr.color;
        transform.localScale = Vector3.one * 3f;
        target = FindNearestTarget();
    }

    void Update()
    {
        currentState.Execute(this);
        CheckIfReachedGoal();
    }

    public override void Move() { }

    Transform FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        Transform nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = obj.transform;
            }
        }

        return nearest;
    }

    void CheckIfReachedGoal()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < 0.2f)
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    void OnMouseDown()
    {
        Die();
    }

    public void Die()
    {
        GameManager.Instance.AddScore(10);
        Destroy(gameObject);
    }
}
