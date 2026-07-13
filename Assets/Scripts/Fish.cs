using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed = 2f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, -95, 0);
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -30f)
        {
            Destroy(gameObject);
        }
    }
}