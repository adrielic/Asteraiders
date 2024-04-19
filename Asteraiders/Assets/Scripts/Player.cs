using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private float moveSpeed = 8f, reloadTimer;
    private int ammo = 3;
    private Rigidbody2D playerRb;
    private PolygonCollider2D playerPolyCol;
    private Animator playerAnim;

    public static bool isDead = false;
    public RuntimeAnimatorController playerAnimController;
    public GameObject projectile;
    public AudioSource playerAudioSource;
    public AudioClip laserShot;

    void Start()
    {
        InitializeComponents();
        Debug.Log(isDead);
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void InitializeComponents()
    {
        gameObject.AddComponent<PolygonCollider2D>();
        playerPolyCol = gameObject.GetComponent<PolygonCollider2D>();

        gameObject.AddComponent<Rigidbody2D>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        playerRb.freezeRotation = true;
        playerRb.gravityScale = 0;

        gameObject.AddComponent<Animator>();
        playerAnim = gameObject.GetComponent<Animator>();
        playerAnim.runtimeAnimatorController = playerAnimController;

        gameObject.AddComponent<AudioSource>();
        playerAudioSource = gameObject.GetComponent<AudioSource>();        
    }

    void Move()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector2(dirX, dirY) * moveSpeed;
        playerRb.AddForce(Vector3.left * 1.5f * 3f, ForceMode2D.Impulse);

        if (dirX > 0)
        {
            playerAnim.Play("Forward");
        }
        else if (dirX == 0 || dirX < 0)
        {
            playerAnim.Play("Stopping");
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Instantiate(projectile, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.42f), Quaternion.identity);
            Instantiate(projectile, new Vector2(transform.position.x + 0.5f, transform.position.y - 0.42f), Quaternion.identity);

            ammo--;
            playerAudioSource.PlayOneShot(laserShot, 0.5f);
            Debug.Log("Ammo: " + ammo);
        }

        while (ammo == 0)
        {
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= 1f)
            {
                ammo = 3;
                Debug.Log("Ammo: " + ammo);
                reloadTimer = 0f;
            }

            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            isDead = true;
            Destroy(gameObject);
            Destroy(col.gameObject);
            Debug.Log("Dead");
            
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}
