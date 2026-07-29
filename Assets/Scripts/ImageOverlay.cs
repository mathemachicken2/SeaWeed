using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageOverlay : MonoBehaviour
{
    public Image overlayImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        StartCoroutine(FadeFromWhite());
    }

    public IEnumerator FadeToWhite()
    {
        yield return Fade(0f, 1f);
    }

    public IEnumerator FadeFromWhite()
    {
        yield return Fade(1f, 0f);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color color = overlayImage.color;

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            overlayImage.color = color;

            yield return null;
        }

        color.a = endAlpha;
        overlayImage.color = color;
    }
}