using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions; //for REGEX
using UnityEngine;
using UnityEngine.Networking;

public class API_Request : MonoBehaviour
{
    #region Parameters

    // Tower Spawner script components:
    [SerializeField] private TowerSpawner TowerSpawner6thGrade;
    [SerializeField] private TowerSpawner TowerSpawner7thGrade;
    [SerializeField] private TowerSpawner TowerSpawner8thGrade;

    // Api request URL:
    private string url = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
    // List of Jenga block data objects:
    private List<JengaBlockData> Pieces6thGradeList = new List<JengaBlockData>();
    private List<JengaBlockData> Pieces7thGradeList = new List<JengaBlockData>();
    private List<JengaBlockData> Pieces8thGradeList = new List<JengaBlockData>();

    #endregion


    #region Custom Methods

    private JengaBlockDataListObject ParseData(string request_text)
    {
        /***
         * Receives a request text in JSON format and properly stores it
         * in a list of objects, returning it.
         ***/

        // Create object to store data:
        JengaBlockDataListObject dataList = JsonUtility.FromJson<JengaBlockDataListObject>(request_text);
        return dataList;
        
    }

    private void DataPreProcessing(JengaBlockDataListObject fullDataList)
    {
        /***
         * Loops over all data and stores is in separate lists, one for each
         * tower.
         ***/

        foreach (JengaBlockData block in fullDataList.jengaBlockDataList)
        {
            if (block.grade == "6th Grade")
            {
                Pieces6thGradeList.Add(block);
            }
            else if (block.grade == "7th Grade")
            {
                Pieces7thGradeList.Add(block);
            }
            else if (block.grade == "8th Grade")
            {
                Pieces8thGradeList.Add(block);
            }
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return request.SendWebRequest();

            // Treat request
            switch (request.result)
            {
                // Error:
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(request.error);
                    break;
                // Success:
                case UnityWebRequest.Result.Success:
                    //API call worked:
                    Debug.Log("Deu sucesso!");

                    // Adapt API request text to be a full JSON:
                    string json_string = "{ \"jengaBlockDataList\":" + request.downloadHandler.text + "}";
                    // Properly store retrieved information in a class:
                    JengaBlockDataListObject fullDataList = ParseData(json_string);
                    Debug.Log(fullDataList.jengaBlockDataList.Count);
                    
                    // Separate data in 3 lists, one for each Jenga tower:
                    DataPreProcessing(fullDataList);
                    // Spawns all 3 towers:
                    TowerSpawner6thGrade.TowerSpawn(Pieces6thGradeList);
                    TowerSpawner7thGrade.TowerSpawn(Pieces7thGradeList);
                    TowerSpawner8thGrade.TowerSpawn(Pieces8thGradeList);
                    break;
            }
        }
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Awake()
    {
        // Execute get request on desired API:
        StartCoroutine(GetRequest(url));

    }

    #endregion
}
