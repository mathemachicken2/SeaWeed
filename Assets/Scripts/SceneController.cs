using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public ImageOverlay imageOverlay;

    public void LoadNextScene()
    {
        StartCoroutine(FadeAndLoadNext());
    }

    IEnumerator FadeAndLoadNext()
    {
        // Fade to white
        yield return imageOverlay.FadeToWhite();

        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current + 1);

        // Wait for new scene to load
        yield return new WaitForSeconds(0.2f);

        // Fade back in
        yield return imageOverlay.FadeFromWhite();
    }

    public void LoadMainMenu()
    {
        StartCoroutine(FadeAndLoadMainMenu());
    }

    IEnumerator FadeAndLoadMainMenu()
    {
        yield return imageOverlay.FadeToWhite();

        SceneManager.LoadScene("MainMenu");

        yield return new WaitForSeconds(0.2f);

        yield return imageOverlay.FadeFromWhite();
    }
}