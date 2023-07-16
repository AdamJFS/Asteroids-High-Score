using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;



public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;

    public float minSize = 0.5f;

    public float maxSize = 1.5f;

    public float astSpeed = 5.0f;

    public float maxLifeTime = 30.0f;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    public AudioPlayer audioPlayer;

    BoxCollider2D boxCollider;

    


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider= GetComponent<BoxCollider2D>();
        
        
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * size;

        rb.mass = size;
        Destroy(gameObject, maxLifeTime);
        
    }

    public void SetTrajectory(Vector2 diriction)
    {
        rb.AddForce(diriction * this.astSpeed);

        Destroy(gameObject, maxLifeTime);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((size * 0.5f) >= this.minSize)
            {
                CreateSplite();
                CreateSplite();
            }

            ExplosionEffect();
            audioPlayer.PlayDamageClip();
            Destroy(this.gameObject);
  
        }
        
    }

    private void CreateSplite()
    {
        boxCollider.enabled = true;
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * astSpeed);
        
        
    }

    
    private void ExplosionEffect()
    {
        FindObjectOfType<GameManager>().AsteroidDestroed(this);
    }
    





}
