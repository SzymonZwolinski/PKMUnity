using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace asd
{
	public class UnitSpawnField : MonoBehaviour
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
				PlayerCollider.transform.position != LastPlayerPosition)
			{
				if (Random.Range(1, 101) == 1)
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