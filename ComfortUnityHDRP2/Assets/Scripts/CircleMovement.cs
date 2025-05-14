using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float speed = 1f;
    public float size = 3f;

    private Vector3 center;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        float t = Time.time * speed;

        // Parametric figure-8 (Lemniscate of Gerono)
        float x = Mathf.Sin(t) * size;
        float z = Mathf.Sin(t) * Mathf.Cos(t) * size;

        Vector3 newPosition = new Vector3(x, 0f, z) + center;
        transform.position = newPosition;

        // Compute forward direction using derivative (approximate with delta)
        float dt = 0.01f;
        float x2 = Mathf.Sin(t + dt) * size;
        float z2 = Mathf.Sin(t + dt) * Mathf.Cos(t + dt) * size;
        Vector3 futurePosition = new Vector3(x2, 0f, z2) + center;
        Vector3 direction = (futurePosition - newPosition).normalized;

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }
}