using UnityEngine;

public class FastEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        speed = 2f;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.yellow;
        sr.sortingOrder = 2;
        transform.localScale = Vector3.one * 3f;
        originalColor = sr.color;
    }
}
