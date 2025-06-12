using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public int speed;
    public int rotationSpeed;
    public Transform Camera;
    public Vector3 movementDirection;

    public void rotateCamera(Vector3 direction)
    {
        Camera.Rotate(direction * rotationSpeed * Time.deltaTime);
    }
    public void moveCamera(Vector3 direction)
    {
        Camera.Translate(direction * speed * Time.deltaTime);
    }
    void Start()
    {
        // Initialize camera position and rotation if needed
        Camera = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationDirection = Vector3.zero;
        movementDirection = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            movementDirection = new Vector3 (0,1,1);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            movementDirection = new Vector3(0, -1, -1);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            movementDirection = Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            movementDirection = Vector3.right;
        }
        if (Keyboard.current.qKey.isPressed)
        {
            rotationDirection = new Vector3(0,1,-1);
        }
        if (Keyboard.current.eKey.isPressed)
        {
            rotationDirection = new Vector3(0, -1, 1);
        }

        if(rotationDirection != Vector3.zero)
        {
            rotateCamera(rotationDirection);
        }

        if(movementDirection != Vector3.zero)
        {
            moveCamera(movementDirection);
        }
    }
}
