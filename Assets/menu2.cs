using UnityEngine;
using UnityEngine.SceneManagement;
public class menu2 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
