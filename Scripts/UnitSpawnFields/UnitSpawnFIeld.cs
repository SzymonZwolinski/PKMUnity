using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BaseUnitSpawnField : MonoBehaviour
{
	public CapsuleCollider playerCollider;
	public BoxCollider terrainCollider;
	public List<int> spawnableUnits = new List<int>(); // TODO: Add some static factory to create units based on int Id 
	private int oddsToSpawnUnit = 1; // That means 1 unit per 100 ticks. Right now assume that every unit has exact spawn chance

	private void Start()
	{
		playerCollider = FindObjectOfType<CapsuleCollider>();
		// Right now only the player has a CapsuleCollider
	}

	private void FixedUpdate()
	{
		if (terrainCollider.isTrigger)
		{
			Debug.Log("An object is in the collider zone");
			int randomValue = UnityEngine.Random.Range(1, 101);
			if (oddsToSpawnUnit == randomValue)
			{
				SpawnUnit();
			}
		}
	}

	private void SpawnUnit()
	{
		// TODO: Spawn a box and assign myUnitClass to it
		var myUnit = new FirstTestUnit();

		var box = GameObject.CreatePrimitive(PrimitiveType.Cube);
		var unitComponent = box.AddComponent<FirstTestUnit>();

		var myUnitFields = myUnit.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
		var unitComponentFields = unitComponent.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

		foreach (var field in myUnitFields)
		{
			var value = field.GetValue(myUnit);
			var correspondingField = Array.Find(unitComponentFields, f => f.Name == field.Name);
			if (correspondingField != null)
			{
				correspondingField.SetValue(unitComponent, value);
			}
		}
	}
}
