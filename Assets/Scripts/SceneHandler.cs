using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    #region Parameters

    // Scene name to be loaded at awake of game:
    [SerializeField] private List<string> sceneNames_loadOnAwake;

#endregion


    #region Custom Methods

    public void LoadScene(string scene_name)
    {
        /***
         * Assynchronously loads the desired scene based on it's name over 
         * the already loaded scenes.
         * 
         * Input:
         *     string scene_name: Name of the desired Unity Scene.
         * 
         * Output:
         *     None
         ***/

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
    }

    public void LoadScenesInBatch(List<string> scene_names)
    {
        /***
         * Assynchronously loads the desired scenes based on it's name over 
         * the already loaded scenes.
         * 
         * Input:
         *     List<string> scene_names: List with all names of the desired Unity Scenes.
         * 
         * Output:
         *     None
         ***/

        foreach (string scene_name in scene_names)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
        }
        
    }

    public void UnloadScene(string scene_name)
    {
        /***
         * Assynchronously unloads the desired scene based on it's name over 
         * the already loaded scenes.
         * 
         * Input:
         *     string scene_name: Name of the desired Unity Scene.
         * 
         * Output:
         *     None
         ***/

        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene_name);
    }

    public void UnloadScenesInBatch(List<string> scene_names)
    {
        /***
         * Assynchronously unloads the desired scenes based on it's name over 
         * the already loaded scenes.
         * 
         * Input:
         *     List<string> scene_names: List with all names of the desired Unity Scenes.
         * 
         * Output:
         *     None
         ***/

        foreach (string scene_name in scene_names)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene_name);
        }

    }

    //metodo de load assynch aditivo em batch com base em lista de nomes
    //metodo de unload assynch com base em 1 nome
    //metodo de unload assynch em batch com base em lista de nomes

    #endregion


    #region Built-in Methods

    void Awake()
        {
            // Load first scene of game:
            LoadScenesInBatch(sceneNames_loadOnAwake);
        }

    #endregion

}
