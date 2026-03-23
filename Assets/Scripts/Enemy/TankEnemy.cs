using UnityEngine;

public class TankEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        speed = 1f;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0.6f, 0f, 0.8f);
        sr.sortingOrder = 2;
        transform.localScale = Vector3.one * 4.5f;
        originalColor = sr.color;
    }
}
