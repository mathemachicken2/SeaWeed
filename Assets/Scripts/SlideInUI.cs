using UnityEngine;
using System.Collections;

public class SlideInUI : MonoBehaviour
{
    public RectTransform image;

    public Vector2 startPosition;
    public Vector2 targetPosition;

    public float delay = 2f;
    public float slideDuration = 0.75f;

    private void Start()
    {
        image.anchoredPosition = startPosition;
        StartCoroutine(SlideIn());
    }

    IEnumerator SlideIn()
    {
        yield return new WaitForSeconds(delay);

        Vector2 start = image.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / slideDuration;

            // Smooth easing
            t = Mathf.SmoothStep(0f, 1f, t);

            image.anchoredPosition = Vector2.Lerp(start, targetPosition, t);
            yield return null;
        }

        image.anchoredPosition = targetPosition;
    }
}