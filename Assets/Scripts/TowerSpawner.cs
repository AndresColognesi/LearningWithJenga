using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    #region Parameters

    // Jenga block data script component:
    [SerializeField] private API_Request APIRequestScript;
    // List of jenga block data:
    private List<JengaBlockData> towerDataList;

    // Jenga piece prefab:
    [SerializeField] private GameObject JengaPiecePrefab;

    // Staking offset values:
    private float height_offset = 0.015f;
    private float lateral_offset = 0.025f;
    private float epsilon = 0.001f; //so that pieces don't clip on each other

    #endregion

    #region Custom Methods
    
    public void TowerSpawn(List<JengaBlockData> jengaBlocksList)
    {
        /***
         * Receives the desired tower jenga blocks and builds it up
         * spawning all jenga pieces. The information of each block
         * is stored in the instance of the prefab. The material is
         * set, as well as the object tag, according to the mastery
         * data of the Jenga blocks.
         ***/

        // Store list in this object:
        towerDataList = jengaBlocksList;

        // Create quotient variable for level control:
        float quotient;
        int int_quotient;
        // Coordinates to instantiate piece:
        float x;
        float y;
        float z;
        Quaternion rotation_angle;
        float lateral_displacement;

        // Index for position within the jenga tower level:
        int in_level_count = 1;
        // Loop over data list:
        for (int i = 0; i < jengaBlocksList.Count; i++)
        {
            // Calculate lateral displacement:
            if (in_level_count == 1)
            {
                lateral_displacement = -(lateral_offset + epsilon);
            }
            else if (in_level_count == 2)
            {
                lateral_displacement = 0f;
            }
            else
            {
                lateral_displacement = lateral_offset + epsilon;
            }

            // Get current level by dividing index by 3 and getting integer part:
            quotient = i/3;
            int_quotient = (int)quotient;
            // Set orientation based on even or odd integer value:
            if (int_quotient % 2 > 0f) //odd level
            {
                // Reset z value:
                z = 0f;
                // Set lateral displacement to x:
                x = lateral_displacement;
                // Add 90º to y roatation in quaternion:
                rotation_angle = new Quaternion(0.7071f, 0f, 0.7071f, 0f);
            }
            else //even level
            {
                // Reset x value:
                x = 0f;
                // Set lateral displacement to z:
                z = lateral_displacement;
                // Don't add any additional rotation angle:
                rotation_angle = new Quaternion(0f, 0f, 0f, 0f);
            }

            // Calculate height based on offset:
            y = int_quotient * height_offset + epsilon;
            

            // Instantiate jenga piece object based on local displacements, parented to this game object:
            Instantiate(JengaPiecePrefab, new Vector3(x, y, z), rotation_angle, gameObject.transform);

            // Update level counter:
            if (in_level_count < 3)
            {
                in_level_count++;
            }
            else
            {
                // Reset level counter:
                in_level_count = 1;
            }
        }
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    #endregion
}
