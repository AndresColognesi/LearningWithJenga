using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyStack : MonoBehaviour
{
    #region Parameters

    // Camera Manager Script to get current tower on focus:
    [SerializeField] private CameraManager cameraManager;

    // Tower Spawners:
    [SerializeField] private GameObject[] towerSpawnerArray;

    #endregion


    #region Custom Methods

    public void EnableTestMyStack()
    {
        /***
         * Removes all glass pieces and enables physics on all pieces
         * from the tower on focus.
         ***/

        // Loop over all pieces in current tower of focus:
        foreach (Transform child in towerSpawnerArray[cameraManager.GetCurrentStackIndex()].transform)
        {
            // Disable glass pieces:
            if (child.tag == "Glass")
            {
                child.gameObject.SetActive(false);
            }
            // Enable gravity for object:
            child.gameObject.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    public void RebuildStack()
    {
        /***
         * Destroy all pieces and rebuilds the tower on focus.
         ***/

        // Store current stack index:
        int currentIndex = cameraManager.GetCurrentStackIndex();
        // Loop over all pieces in current tower of focus:
        foreach (Transform child in towerSpawnerArray[currentIndex].transform)
        {
            // Delete piece:
            Destroy(child.gameObject);
        }
        // Recreate tower:
        towerSpawnerArray[currentIndex].GetComponent<TowerSpawner>().RebuidTower();
    }

    #endregion

}
