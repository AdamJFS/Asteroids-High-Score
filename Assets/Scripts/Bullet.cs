using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed = 500.0f;

    public float maxLifeTime = 1.0f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * this.bulletSpeed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
