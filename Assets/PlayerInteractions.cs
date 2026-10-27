using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float fallLimitY = -10f; 
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position; 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddCoin();
            }
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Goal"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.LevelComplete();
            }
        }
    }

    // COLLISION = something SOLID we bump into (spikes)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // stop all movement
        }
    }
}