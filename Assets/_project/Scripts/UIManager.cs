using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void Quit()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }
}
