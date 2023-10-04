using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private Scene MainScene;

	private void Start()
	{
		MainScene = SceneManager.GetSceneByName(SceneNames.v1.ToString());
	}

	public void UnloadBattleScene()
    {
        CheckIfMainSceneIsInitalized();
		EnableMainSceneObjects();

		var unloadSceneAsycnTask =
            SceneManager.UnloadSceneAsync(SceneNames.BattleScene.ToString());
	}

    public void LoadBattleSceneAsync()
    {
        CheckIfMainSceneIsInitalized();

		var loadSceneAsyncTask = 
            SceneManager.LoadSceneAsync(SceneNames.BattleScene.ToString(), LoadSceneMode.Additive);

        DisableMainSceneObjects();
    }

	private void DisableMainSceneObjects()
	    => MainScene.GetRootGameObjects().ToList().ForEach(x => x.SetActive(false));

    private void EnableMainSceneObjects()
        => MainScene.GetRootGameObjects().ToList().ForEach(x => x.SetActive(true));

    private void CheckIfMainSceneIsInitalized()
    {
        if(MainScene != null) 
        {
            return;
        }

        MainScene = SceneManager.GetSceneByName(SceneNames.v1.ToString());
	}

    /*private void InitalizeMainSceneProperties()
    {
		var currentScene = SceneManager.GetActiveScene();
        
		rootObjects = mainScene.GetRootGameObjects().ToList();
	}*/
}
