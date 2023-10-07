using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace asd
{
	public class UnitSpawnField : MonoBehaviour
	{
		public List<int> spawnableUnits = new List<int>(); // TODO: Add some static factory to create units based on int Id 
		private int oddsToSpawnUnit = 1; // That means 1 unit per 100 ticks. Right now assume that every unit has exact spawn chance
		[SerializeField]
		private bool triggerActive = false;
		private Vector3 LastPlayerPosition;
		private Collider PlayerCollider;

		public void OnTriggerEnter(Collider playerCollider)
		{
			if (playerCollider.CompareTag("Player"))
			{
				triggerActive = true;
				PlayerCollider = playerCollider;
				LastPlayerPosition = playerCollider.transform.position;
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				triggerActive = false;
			}
		}

		private void Update()
		{
			if (triggerActive && PlayerCollider.transform.position != LastPlayerPosition)
			{
				if (UnityEngine.Random.Range(0, 100) == 1)
				{
					var myUnit = new FirstTestUnit();
					SpawnUnit(myUnit);
				}

				LastPlayerPosition = PlayerCollider.transform.position;
			}
		}

		private void SpawnUnit(BaseUnit unitToSpawn)
		{
			// TODO: Spawn a box and assign myUnitClass to it
			asd.SceneChanger.LoadBattleSceneAsync(SceneManager.GetActiveScene());

			var box = GameObject.CreatePrimitive(PrimitiveType.Cube);
			box.AddComponent<StatHolder>()
				.UnitStats = unitToSpawn;


		}

		//TODO: Add instafight and despawn method
	}
}