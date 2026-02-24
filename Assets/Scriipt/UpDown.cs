using UnityEngine;

public class UpDownMover : MonoBehaviour
{
    public float height = 2f;   // how high it moves
    public float speed = 2f;    // how fast it moves

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * height;
        transform.position = startPos + Vector3.up * yOffset;
    }
}
