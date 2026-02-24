using UnityEngine;

public class Spin : MonoBehaviour
{
   // public float spinSpeed = 10f;
    public Vector3 rotationSpeed = new Vector3 (0, 90f, 0);
    void Start()
    {
        
    }

    
    void Update()
    {
        

        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
