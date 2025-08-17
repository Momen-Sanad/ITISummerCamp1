using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void ReturnToMainMenu()
    {
        // Reset timescale in case gameplay was paused
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
