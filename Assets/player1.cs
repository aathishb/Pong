using UnityEngine;
public class player1 : MonoBehaviour
{
    Vector2 targetPos;
    public float speed;
    public float step;
    float bound = 3.5f;
    float xpos = -7.2f;
    void Start()
    {
        targetPos = new Vector2(xpos,0);
        transform.position = new Vector2(xpos,0);
    }
    void Update()
    {
        if (Input.GetKey("w") && transform.position.y < bound)
        {
            targetPos = new Vector2(xpos, transform.position.y + step);
        }
        if (Input.GetKey("s") && transform.position.y > -bound)
        {
            targetPos = new Vector2(xpos, transform.position.y - step);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
