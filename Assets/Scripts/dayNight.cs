using UnityEngine;

public class dayNight : MonoBehaviour
{
    public Light lightSource;
    public float rotationSpeed;
    void Update()
    {
        lightSource.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
