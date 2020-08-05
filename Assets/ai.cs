using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public int difficulty;
    public Vector2 ballDir;
    Transform ball;
    Vector2 ballPos0;
    Vector2 ballPos1;
    Vector2 targetPos;
    public float goToPos;
    public float speed;
    public float step;
    float step2 = 0.2f;
    float stepAi = 0.158f;
    public float theta;
    public float lim;
    float bound = 3.5f;
    float xpos = 7.2f;
    void Start()
    {
        ball = FindObjectOfType<ball_behaviour>().transform;
        ballPos1 = new Vector2(0,0);
        targetPos = new Vector2(xpos,0);
        transform.position = new Vector2(xpos, 0);
    }

    void Update()
    {
        switch (difficulty)
        {
            case 0:
                calc0();
                break;
            case 1:
                calc1();
                break;
            case 2:
                lim = -2;
                calc2();
                break;
            case 3:
                lim = -8;
                calc2();
                break;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        ballPos0 = ballPos1;
        ballPos1 = new Vector2(ball.position.x, ball.position.y);
        ballDir = 50*(ballPos1 - ballPos0);        
    }

    void calc0()
    {
        step = step2;
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < bound)
        {
            targetPos = new Vector2(xpos, transform.position.y + step);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -bound)
        {
            targetPos = new Vector2(xpos, transform.position.y - step);
        }
    }

    void calc1()
    {
        if (ball.position.x > -1 && ballDir.x > 0)
        {
            // Blindly follows ball
            step = stepAi;
            if (ball.position.y > transform.position.y && transform.position.y < bound)
            {
                if (transform.position.y < ball.position.y + 0.5 && transform.position.y > ball.position.y - 0.5)
                {
                    targetPos = new Vector2(xpos, transform.position.y);
                }
                else
                {
                    targetPos = new Vector2(xpos, transform.position.y + step);
                }
            }
            else if (ball.position.y < transform.position.y && transform.position.y > -bound)
            {
                if (transform.position.y < ball.position.y + 0.5 && transform.position.y > ball.position.y - 0.5)
                {
                    targetPos = new Vector2(xpos, transform.position.y);
                }
                else
                {
                    targetPos = new Vector2(xpos, transform.position.y - step);
                }
            }
        }
    }

    void calc2()
    {
        if (ballDir.x > 0 && ball.position.x > lim)
        {
            // Calculates where ball is going to be and moves there
            step = stepAi;
            float tempO = Mathf.Atan(Mathf.Abs(ballDir.y / ballDir.x));
            if (ballDir.y > 0)
            {
                theta = tempO;
            }
            else
            {
                theta = 2 * Mathf.PI - tempO;
            }

            float x = transform.position.x - ball.position.x;
            float y = x * Mathf.Tan(theta);
            goToPos = ball.position.y + y;
            if (transform.position.y < goToPos && transform.position.y < bound && goToPos < 9)
            {
                if (!(transform.position.y < goToPos + 0.5 && transform.position.y > goToPos - 0.5))
                {
                    targetPos = new Vector2(xpos, transform.position.y + step);
                }
                else
                {
                    targetPos = new Vector2(xpos, transform.position.y);
                }
            }
            if (transform.position.y > goToPos && transform.position.y > -bound && goToPos > -9)
            {
                if (!(transform.position.y < goToPos + 0.5 && transform.position.y > goToPos - 0.5))
                {
                    targetPos = new Vector2(xpos, transform.position.y - step);
                }
                else
                {
                    targetPos = new Vector2(xpos, transform.position.y);
                }
            }
        }
    }
}
