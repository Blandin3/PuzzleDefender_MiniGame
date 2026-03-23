using UnityEngine;

public class MoveState : IEnemyState
{
    public void Execute(Enemy enemy)
    {
        if (enemy.target == null) return;

        Vector2 current = enemy.transform.position;
        Vector2 target = enemy.target.position;
        Vector2 direction = target - current;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            current.x += Mathf.Sign(direction.x) * enemy.speed * Time.deltaTime;
        else
            current.y += Mathf.Sign(direction.y) * enemy.speed * Time.deltaTime;

        enemy.transform.position = current;
    }
}
