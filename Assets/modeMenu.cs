using UnityEngine;

public class modeMenu : MonoBehaviour
{
    public GameObject ModeMenu;

    public void easyMode()
    {
        ModeMenu.SetActive(false);
        FindObjectOfType<ai>().difficulty = 1;
        Invoke("callInitialise", 1.7f);
    }
    public void normalMode()
    {
        ModeMenu.SetActive(false);
        FindObjectOfType<ai>().difficulty = 2;
        Invoke("callInitialise", 1.7f);
    }
    public void hardMode()
    {
        ModeMenu.SetActive(false);
        FindObjectOfType<ai>().difficulty = 3;
        Invoke("callInitialise", 1.7f);
    }
    public void twoPlayerMode()
    {
        ModeMenu.SetActive(false);
        FindObjectOfType<ai>().difficulty = 0;
        Invoke("callInitialise", 1.7f);
    }

    void callInitialise()
    {
        FindObjectOfType<ball_behaviour>().initialise();
    }
}
