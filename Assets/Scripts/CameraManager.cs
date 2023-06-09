using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Parameters

    // Array of transforms for desired camera anchors:
    [SerializeField] private Transform[] cameraAnchorArray;
    // Array of all stack transforms:
    [SerializeField] private Transform[] stackTransformArray;

    // Mouse Camera Movement Parameters //
    // Mouse sensitivity to hover:
    [SerializeField] private float mouseSensitivity = 3.0f;
    // Current rotations:
    private float rotationY;
    private float rotationX;
    private Vector3 currentRotation;
    // Rotation smoothness parameters:
    private Vector3 smoothVelocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.2f;
    // Rotation limits in Euler Angles:
    [SerializeField] private Vector2 rotationXMinMax = new Vector2(15, 40);
    // Height offset to rotate camera around tower:
    [SerializeField] private float towerHeightOffset = 0.1f;

    // Store current stack on focus:
    private int currentStackIndex;
    // Store current stack radius (camera - stack distance):
    private float currentRadius;

    #endregion


    #region Custom Methods

    public void SetCameraToAnchor(string towerName)
    {
        /***
         * Places the gamera on the desired position and
         * rotation based on the tower name (grade).
         ***/

        // Store desired array index based on tower name:
        int desired_index = 0; //6th grade as default
        switch (towerName)
        {
            case ("6th Grade"):
                desired_index = 0;
                break;
            case ("7th Grade"):
                desired_index = 1;
                break;
            case ("8th Grade"):
                desired_index = 2;
                break;
        }
        // Set position and rotation of camera:
        gameObject.transform.position = cameraAnchorArray[desired_index].position;
        gameObject.transform.rotation = cameraAnchorArray[desired_index].rotation;
        // Store current stack that is focused on and radius:
        currentStackIndex = desired_index;
        currentRadius = Mathf.Abs((cameraAnchorArray[desired_index].position - stackTransformArray[desired_index].position).magnitude);
    }

    public int GetCurrentStackIndex()
    {
        /***
         * Retrieve index of current tower on focus.
         ***/

        return currentStackIndex;
    }

    private void MouseCameraRotation()
    {
        /***
         * Rotate the camera (this game object) around the desired
         * tower/stack.
         ***/

        // Get mouse left click input:
        float mouseX = -Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        // Update current axis rotations:
        rotationY += mouseX;
        rotationX += mouseY;
        // Clamp X rotation: 
        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        // Calculate next rotation abd apply damping:
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        // Apply final desired rotation:
        transform.localEulerAngles = currentRotation;

        // Point camera to stack and place in defined distance:
        transform.position = (stackTransformArray[currentStackIndex].position + new Vector3(0f, towerHeightOffset, 0f)) - transform.forward * currentRadius;
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Start()
    {
        // Set camera to focus a default tower:
        SetCameraToAnchor("7th Grade");
    }

    void Update()
    {
        // When right mouse click remains pressed:
        if (Input.GetMouseButton(1))
        {
            MouseCameraRotation();
        }
    }

    #endregion
}
