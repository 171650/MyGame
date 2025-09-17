using Unity.Mathematics;
using UnityEngine;

public class playercam_movement : MonoBehaviour
{
    public float sensx = 360;
    public float sensy = 360;
    public Transform orientation;
    float xrotation;
    float yrotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensy;

        yrotation += mouseX;
        xrotation -= mouseY;
        // prevents camera from flipping
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        //
        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);
    }
}
