using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Death : MonoBehaviour
{
    public string mainMenuScene = "MainMenu";
    public float delayBeforeReturn = 3f;       // seconds to wait before going to menu

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hi 1");
            Animator playerAnimator = collision.GetComponent<Animator>();
            if (playerAnimator)
            {
                Debug.Log("hi 2");
                playerAnimator.SetBool("isDead", true);
            }

            // Disable player controls
            PlayerMovement controller = collision.GetComponent<PlayerMovement>();
            Debug.Log("hi 3");

            if (controller)
                controller.enabled = false;
            

            // Return to menu after short delay
            StartCoroutine(ReturnToMenu());
        }
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(delayBeforeReturn);
        SceneManager.LoadScene(mainMenuScene);
    }
}
