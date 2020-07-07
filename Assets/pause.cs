using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public static bool isPaused;
    public GameObject panel;

    void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseGame();
            }
            else if (isPaused)
            {
                resume();
            }
        }
    }
    public void pauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void retry()
    {
        isPaused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
    public void openMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
        SceneManager.LoadScene("menu");
    }
}
