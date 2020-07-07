using UnityEngine;
public class player2 : MonoBehaviour
{
    Vector2 targetPos;
    public float speed;
    public float step;
    void Start()
    {
        targetPos = new Vector2(8,0);
        transform.position = new Vector2(8, 0);
    }
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
