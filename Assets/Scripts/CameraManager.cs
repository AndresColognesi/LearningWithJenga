using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Parameters

    // Array of transforms for desired camera anchors:
    [SerializeField] private Transform[] cameraAnchorArray;

    // Store current stack on focus:
    private int currentStackIndex;

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
        // Store current stack that is focused on:
        currentStackIndex = desired_index;
    }

    public int GetCurrentStackIndex()
    {
        /***
         * Retrieve index of current tower on focus.
         ***/

        return currentStackIndex;
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Start()
    {
        // Set camera to focus a default tower:
        SetCameraToAnchor("7th Grade");
    }

    #endregion
}
