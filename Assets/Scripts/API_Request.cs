using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API_Request : MonoBehaviour
{
    #region Parameters

    // Api request URL:
    private string url = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";

    #endregion


    #region Custom Methods

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
                    Debug.Log("Deu sucesso!");
                    Debug.Log(request.downloadHandler.text);
                    //= JsonUtility.FromJson<PlayerStatus>(request.downloadHandler.text);
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
        StartCoroutine(GetRequest(url));
    }

    #endregion
}
