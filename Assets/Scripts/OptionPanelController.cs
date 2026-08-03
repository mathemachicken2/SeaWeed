using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class OptionPanelController : MonoBehaviour
{
    public Image endingImage;
    public Sprite option1Sprite;
    public Sprite option2Sprite;

    public Image whiteFadeImage;

    public TMP_Text endingText;
    public string option1Text;
    public string option2Text;

    public float fadeDuration = 4f;
    public float shakeAmount = 5f;
    public float shakeDuration = 0.5f;

    private Vector3 textOriginalPosition;

    

    void Start()
    {
        Color c = whiteFadeImage.color;
        c.a = 0f;
        whiteFadeImage.color = c;

        Color textColor = endingText.color;
        textColor.a = 0f;
        endingText.color = textColor;

        GameObject choicePanel = GameObject.Find("ChoicePanel");

        if (choicePanel != null)
        {
            choicePanel.SetActive(false);
        }

        textOriginalPosition = endingText.transform.localPosition;
    }

    public void Option1()
    {
        StartCoroutine(ShowEnding(option1Sprite, option1Text));
    }

    public void Option2()
    {
        StartCoroutine(ShowEnding(option2Sprite, option2Text));
    }

    IEnumerator ShowEnding(Sprite sprite, string text)
    {
        // Fade to white
        yield return Fade(0f, 1f);

        // Show image
        endingImage.sprite = sprite;
        endingImage.gameObject.SetActive(true);

        // Set text
        endingText.text = text;

        // Fade text in
        yield return FadeText();

        // Shake text
        yield return ShakeText();

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenu");
    }


    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color c = whiteFadeImage.color;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            whiteFadeImage.color = c;
            yield return null;
        }

        c.a = endAlpha;
        whiteFadeImage.color = c;
    }


    IEnumerator FadeText()
    {
        Color c = endingText.color;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, time / fadeDuration);
            endingText.color = c;
            yield return null;
        }
    }


    IEnumerator ShakeText()
    {
        float time = 0;

        while (time < shakeDuration)
        {
            time += Time.deltaTime;

            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);

            endingText.transform.localPosition =
                textOriginalPosition + new Vector3(x, y, 0);

            yield return null;
        }

        endingText.transform.localPosition = textOriginalPosition;
    }
}