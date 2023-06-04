using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    #region Parameters

    // Jenga block data script component:
    [SerializeField] private API_Request APIRequestScript;
    // List of jenga block data:
    private List<JengaBlockData> dataList;

    #endregion

    #region Custom Methods
    //oi
    #endregion

    #region Built-in Methods
    // Start is called before the first frame update
    void Start()
    {
        dataList = APIRequestScript.GetBlockList();
        Debug.Log(dataList[0].standarddescription);
        Debug.Log(dataList[1].standarddescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
