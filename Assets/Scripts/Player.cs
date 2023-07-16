
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private Rigidbody2D rb;

    public Bullet bulletPrefab;

    private bool thrust;

    public GameObject flames;

    public float thrustSpeed = 1.9f;

    public float turnSpeed = 0.2f;

    private float turnDirection;

    public AudioPlayer audioplayer;

    CameraShake cameraShake;

    public Button buttonThrust;

    public Button buttonShoot;

    public Joystick joystick;

    [SerializeField] bool applyCameraShake;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    private void Start()
    {
        Button btn = buttonThrust.GetComponent<Button>();
        btn.onClick.AddListener(ThrustMove);
        Button btn2 = buttonShoot.GetComponent<Button>();
        btn2.onClick.AddListener(Shoot);
        if (!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        flames.SetActive(false);

    }


    private void UpdateCharacter(int selectedOption)
    {
        CharacterSelection character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }


    public void ThrustMove()
    {
        if (thrust)
        {
            rb.AddForce(this.transform.up * this.thrustSpeed);
            flames.SetActive(true);
        }
        else
        {
            flames.SetActive(false);
        }

    }
    public void pointerDown()
    {
        thrust = true;

    }
    public void pointerUp()
    {
        thrust = false;
    }


    private void Update()
    {
        if (joystick.Horizontal == -1)
        {
            turnDirection = 1.0f;
        }
        else if (joystick.Horizontal == 1)
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        //Screen Wraping
        Vector2 newPos = transform.position;        
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;


    }

    private void FixedUpdate()
    {
        if (thrust)
        {
            ThrustMove();

        }
        if (turnDirection != 0.0f)
        {
            rb.AddTorque(turnDirection * this.turnSpeed);
        }
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        audioplayer.PlayShootingClip();
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);
            audioplayer.PlayDamageClip();
            ShakeCamera();
            Die();
            
        }

    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.PlayShake();
        }
    }

    [System.Obsolete]
    private void Die()
    {
        FindObjectOfType<GameManager>().PlayerDied();
    }
}
