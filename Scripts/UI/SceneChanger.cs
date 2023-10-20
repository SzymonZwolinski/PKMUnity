using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace asd
{
	public static class SceneChanger
	{
		private static Scene MainScene;

		private static Vector3 LastPlayerPositionBeforeChangingScene; //to make sure player will return to its original position

		public static void UnloadBattleScene()
		{
			EnableMainSceneObjects();

			var unloadSceneAsycnTask =
				SceneManager.UnloadSceneAsync(SceneNames.BattleScene.ToString());
			UnFreezePlayerMovement();

		}

		public static void LoadBattleSceneAsync(Scene sceneToLoad, Vector3 lastPlayerPos)
		{
			InitalizeMainScene(sceneToLoad);
			InitalizeLastUserPosition(lastPlayerPos);
			FreezePlayerMovement();

			var loadSceneAsyncTask =
				SceneManager.LoadSceneAsync(SceneNames.BattleScene.ToString(), LoadSceneMode.Additive);

			DisableMainSceneObjectsExceptPlayer();
		}

		private static void DisableMainSceneObjectsExceptPlayer()
		{
			var rootObjects = MainScene.GetRootGameObjects();

			foreach (var obj in rootObjects)
			{
				if (!obj.CompareTag("Player"))
				{
					obj.SetActive(false);
				}
			}
		}

		private static void EnableMainSceneObjects()
			=> MainScene
			.GetRootGameObjects()
			.Where(x => !x.CompareTag("Player"))
			.ToList()
			.ForEach(x => x.SetActive(true));

		private static void FreezePlayerMovement()
		{
			GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Movement>().FreezeMovement();			
		}

		private static void UnFreezePlayerMovement()
		{
			GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Movement>().UnFreezeMovement();
		}

		private static void InitalizeMainScene(Scene sceneToLoad)
		{
			MainScene = sceneToLoad;
		}

		private static void InitalizeLastUserPosition(Vector3 lastUserPos)
		{
			LastPlayerPositionBeforeChangingScene = lastUserPos;
		}
	}
}