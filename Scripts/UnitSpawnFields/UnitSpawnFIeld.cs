using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace asd
{
	public class UnitSpawnFIeld : MonoBehaviour
	{
		public List<UnitNames> spawnableUnits = new();

		[SerializeField]
		private bool triggerActive = false;
		private Vector3 LastPlayerPosition;
		private Collider PlayerCollider;

		public void OnTriggerEnter(Collider playerCollider)
		{
			if (playerCollider.CompareTag("PlayerModel"))
			{
				triggerActive = true;
				PlayerCollider = playerCollider;
				LastPlayerPosition = playerCollider.transform.position;
			}
		}

		public void OnTriggerExit(Collider playerCollider)
		{
			if (playerCollider.CompareTag("PlayerModel"))
			{
				triggerActive = false;
			}
		}

		private void Update()
		{
			
			if (triggerActive &&
				(Mathf.Abs(PlayerCollider.transform.position.z - LastPlayerPosition.z) >= 0.5 ||
				Mathf.Abs(PlayerCollider.transform.position.x - LastPlayerPosition.x) >= 0.5))
			{
				var asd = Random.Range(1, 101);
				if (Random.Range(1, 101) <= 90)
				{
					var myUnit = UnitsFactory.GetUnit(
						spawnableUnits[Random.Range(
							0,
							spawnableUnits.Count)]);

					if (UnityEngine.Random.Range(1, 6) <= myUnit.SpawnRate)
					{
						SpawnUnit(myUnit);
					}
				}

				LastPlayerPosition = PlayerCollider.transform.position;
			}
		}

		private void SpawnUnit(BaseUnit unitToSpawn)
		{
			SceneChanger.LoadBattleSceneAsync(SceneManager.GetActiveScene(), LastPlayerPosition);
			
			var unitModel = Resources.Load(unitToSpawn.PrefabPath) as GameObject;
			var spawnedUnit = GameObject.Instantiate(unitModel);

			spawnedUnit.gameObject.tag = "Enemy";

			spawnedUnit.AddComponent<UnitTypeMarker>()
				.UnitType = unitToSpawn;

			spawnedUnit.AddComponent<StatHolder>()
				.UnitStats = unitToSpawn;

			spawnedUnit.transform
				.LookAt(
					GameObject.FindWithTag("MainCamera")
						.transform);
		}
			
	}
}