using TMPro;
using UnityEngine;

public class ui : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI winner;
    public AudioSource a;
    public int p1;
    public int p2;
    public GameObject menu2;
    public GameObject scorePanel;

    void Start()
    {
        p1 = 0; p2 = 0;
    }
    void Update()
    {
        score.text = p1.ToString() + " - " + p2.ToString();

        if (p1 == 5)
        {
            Invoke("gameOver", 1f);
        }
        if (p2 == 5)
        {
            Invoke("gameOver", 1f);
        }
    }
    void gameOver()
    {
        FindObjectOfType<ball_behaviour>().direction = new Vector2(0,0);
        a.enabled = false;
        scorePanel.SetActive(false);
        menu2.SetActive(true);
    }
}
