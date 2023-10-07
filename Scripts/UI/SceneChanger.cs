using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace asd
{
	public static class SceneChanger
	{
		private static Scene MainScene;

		/*private void Start()
		{
			MainScene = SceneManager.GetSceneByName(SceneNames.v1.ToString());
		}*/

		public static void UnloadBattleScene()
		{
			EnableMainSceneObjects();

			var unloadSceneAsycnTask =
				SceneManager.UnloadSceneAsync(SceneNames.BattleScene.ToString());
		}

		public static void LoadBattleSceneAsync(Scene sceneToLoad)
		{
			InitalizeMainScene(sceneToLoad);

			var loadSceneAsyncTask =
				SceneManager.LoadSceneAsync(SceneNames.BattleScene.ToString(), LoadSceneMode.Additive);

			DisableMainSceneObjects();
			Debug.Log(MainScene.GetRootGameObjects().ToString());
			Debug.Log("Scene should be loaded, and objects on main scene disabled");
		}

		private static void DisableMainSceneObjects()
			=> MainScene.GetRootGameObjects().ToList().ForEach(x => x.SetActive(false));

		private static void EnableMainSceneObjects()
			=> MainScene.GetRootGameObjects().ToList().ForEach(x => x.SetActive(true));

		private static void InitalizeMainScene(Scene sceneToLoad)
		{
			MainScene = sceneToLoad;
		}
	}
}