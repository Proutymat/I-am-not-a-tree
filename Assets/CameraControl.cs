using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraControl : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public float yRotation;
    public float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Get X and Y mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX - 90;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation , -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -10f, 10f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
