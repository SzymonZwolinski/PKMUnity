using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaveOnInitailize : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    async void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneChanger.SaveShouldBeLoaded)
        {
            await SaveHandler.LoadSaveSetParameters();
            SceneChanger.SaveShouldBeLoaded = false;  
        }
    }
}
