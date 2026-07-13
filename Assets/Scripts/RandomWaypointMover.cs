using UnityEngine;
using UnityEngine.UI;

public class RandomWaypointMoverUI : MonoBehaviour
{
    public RectTransform waypointA;
    public RectTransform waypointB;

    public float minSpeed = 50f;
    public float maxSpeed = 150f;

    private RectTransform rectTransform;
    private RectTransform target;

    private float speed;
    private bool flipped = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        target = waypointB;
        ChooseNewSpeed();
        UpdateDirection();
    }

    void Update()
    {
        rectTransform.position = Vector3.MoveTowards(
            rectTransform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(rectTransform.position, target.position) < 1f)
        {
            target = (target == waypointA) ? waypointB : waypointA;

            ChooseNewSpeed();
            UpdateDirection();
        }
    }

    void ChooseNewSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void UpdateDirection()
    {
        Vector3 scale = rectTransform.localScale;

        bool shouldFlip = target.position.x < rectTransform.position.x;

        if (shouldFlip != flipped)
        {
            scale.x *= -1;
            rectTransform.localScale = scale;
            flipped = shouldFlip;
        }
    }
}