using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void UnloadBattleScene()
    {
        SceneManager.UnloadSceneAsync(SceneNames.BattleScene.ToString());
    }

    public void LoadBattleSceneAsync()
    {
        var currentScene = SceneManager.GetActiveScene();
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneNames.BattleScene.ToString(), LoadSceneMode.Additive);

        GameObject[] rootObjects = currentScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            obj.SetActive(false);
        }
    }
}
