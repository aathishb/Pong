using UnityEngine;

public class ball_behaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitWall;
    public AudioClip hitPlayer;
    public AudioClip scored;
    public AudioClip gameOver;
    private Rigidbody2D ball;
    public Vector2 direction;
    public float step;
    public float initR;
    public float r;
    private float theta;
    void Start()
    {
        initR = 10f;
        step = 1f;
        r = initR;
        ball = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if ((transform.position.y > 4.3 || transform.position.y < -4.3) &&
            (transform.position.x > -8.9 && transform.position.x < 8.9))
        {
            direction = new Vector2(direction.x, -direction.y);
            audioSource.PlayOneShot(hitWall);
        }
        ball.MovePosition(ball.position + direction * Time.deltaTime);
    }

    private void Update()
    {
        if ((transform.position.x < -8.9 || transform.position.x > 8.9))
        {
            Invoke("restart", 1.2f);
            r = initR;
            direction = new Vector2(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = ++FindObjectOfType<ui_count>().p;
        if (x % 5 == 0)
        {
            r += step;
        }
        float dif = transform.position.y - collision.collider.transform.position.y;
        
        if (collision.collider.tag == "p1")
        {
            if (dif > 0)
            {
                theta = dif;
            }
            else
            {
                theta = 2 * Mathf.PI - Mathf.Abs(dif);
            }
            
        }
        if (collision.collider.tag == "p2")
        {
            float temp = dif;
            theta = dif - 2 * temp + Mathf.PI;
        }

        if (dif > 0)
        {
            direction = new Vector2(-r * Mathf.Cos(theta), r * Mathf.Sin(theta));
        }
        else if (dif < 0)
        {
            direction = new Vector2(-r * Mathf.Cos(theta), r * Mathf.Sin(theta));
        }
        direction = new Vector2(-direction.x, direction.y);
        audioSource.PlayOneShot(hitPlayer);
    }

    public void initialise()
    {
        theta = Random.Range(0, 2 * Mathf.PI);
        direction = new Vector2(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
    }
    private void restart()
    {
        if (transform.position.x < -8.9)
        {
            FindObjectOfType<ui>().p2++;
        }
        if (transform.position.x > 8.9)
        {
            FindObjectOfType<ui>().p1++;
        }
        transform.position = new Vector2(0, 0);
    }
}