using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API_Request : MonoBehaviour
{
    #region Parameters

    // Api request URL:
    private string url = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
    // List of Jenga block data objects:
    private List<JengaBlockData> dataList;

    #endregion


    #region Custom Methods

    private JengaBlockData TESTParseData(string request_text)
    {
        /***
         * Receives a request text in JSON format and properly stores it
         * in a list of objects, returning it.
         ***/
        Debug.Log(request_text);
        // Create object to store data:
        JengaBlockData data = JsonUtility.FromJson<JengaBlockData>(request_text);
        return data;

    }
    private AllData ParseData(string request_text)
    {
        /***
         * Receives a request text in JSON format and properly stores it
         * in a list of objects, returning it.
         ***/
        //List<JengaBlockData> dataList = JsonConvert.DeserializeObject<List<JengaBlockData>>(request_text);
        //return JsonUtility.FromJson<List<JengaBlockData>>(request_text);
        Debug.Log(request_text);
        // Create object to store data:
        AllData dataList = JsonUtility.FromJson<AllData>(request_text);
        return dataList;
        
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
                    string json_string = "{ \"listOfdata\":" + request.downloadHandler.text + "}";
                    // Properly store retrieved information in a class:
                    AllData dataList = ParseData(json_string);
                    Debug.Log(dataList.listOfdata);
                    break;
            }
        }
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Start()
    {
        // Execute get request on desired API:
        //StartCoroutine(GetRequest(url));
        //string test_data = "{\"id\": 2,\"subject\": \"Math\",\"grade\": \"6th Grade\",\"mastery\": 2,\"domainid\": \"RP\",\"domain\": \"Ratios & Proportional Relationships\",\"cluster\": \"Understand ratio concepts and use ratio reasoning to solve problems.\",\"standardid\": \"CCSS.MATH.CONTENT.6.RP.A.1\",\"standarddescription\": \"oi\"}";
        //JengaBlockData data = TESTParseData(test_data);
        //Debug.Log(data.standarddescription);
        //string test_data_full = "{\"listOfData\": [{\"id\": 2,\"subject\": \"Math\",\"grade\": \"6th Grade\",\"mastery\": 2,\"domainid\": \"RP\",\"domain\": \"Ratios & Proportional Relationships\",\"cluster\": \"Understand ratio concepts and use ratio reasoning to solve problems.\",\"standardid\": \"CCSS.MATH.CONTENT.6.RP.A.1\",\"standarddescription\": \"oi\"}]}";
        //AllData dataList = ParseData(test_data_full);
        //Debug.Log(dataList.listOfdata);

        // CREATE TEST DATA LIST TO FINISH PROJECT:
        dataList = new List<JengaBlockData>();
        string test_data = "{\"id\": 2,\"subject\": \"Math\",\"grade\": \"6th Grade\",\"mastery\": 2,\"domainid\": \"RP\",\"domain\": \"Ratios & Proportional Relationships\",\"cluster\": \"Understand ratio concepts and use ratio reasoning to solve problems.\",\"standardid\": \"CCSS.MATH.CONTENT.6.RP.A.1\",\"standarddescription\": \"oi\"}";
        JengaBlockData data = TESTParseData(test_data);
        dataList.Add(data);
        string test_data2 = "{\"id\": 5,\"subject\": \"Math\",\"grade\": \"6th Grade\",\"mastery\": 2,\"domainid\": \"RP\",\"domain\": \"Ratios & Proportional Relationships\",\"cluster\": \"Understand ratio concepts and use ratio reasoning to solve problems.\",\"standardid\": \"CCSS.MATH.CONTENT.6.RP.A.1\",\"standarddescription\": \"tchau\"}";
        JengaBlockData data2 = TESTParseData(test_data2);
        dataList.Add(data2);
        Debug.Log(dataList[0].standarddescription);
        Debug.Log(dataList[1].standarddescription);
    }

    #endregion
}
