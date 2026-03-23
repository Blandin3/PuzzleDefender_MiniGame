using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Time.timeScale = 1f;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.blue;
        sr.sortingOrder = 2;
        transform.localScale = Vector3.one * 1.2f;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }
}
