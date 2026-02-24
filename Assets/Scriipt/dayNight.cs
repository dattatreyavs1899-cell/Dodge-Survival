using UnityEditor;
using UnityEngine;

public class dayNight : MonoBehaviour
{
    public Light light;
    public float rotationSpeed;
    void Update()
    {
        light.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
