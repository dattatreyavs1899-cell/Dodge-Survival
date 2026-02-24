using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    public float mouseSensitivity = 200f;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }


    private void FixedUpdate()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        transform.Translate(xValue, yValue, zValue);
    }
}
