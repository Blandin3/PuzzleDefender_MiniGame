using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float speed = 2f;

    public abstract void Move();
}
