using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public GameObject options;
    public GameObject help;
    public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void helpMenu()
    {
        options.SetActive(false);
        help.SetActive(true);
    }
    public void mainMenu()
    {
        help.SetActive(false);
        options.SetActive(true);
    }
}
