using System;
using System.Collections.Generic;
using UnityEngine;

public static class UnitsFactory
{
	private static Dictionary<UnitNames, Func<BaseUnit>> unitInitDelegates = new ()
	{
		{ UnitNames.FireElemental, CreateFireElemental },
    };

	public static BaseUnit GetUnit(UnitNames unitName)
	{	
		if (unitInitDelegates.TryGetValue(unitName, out Func<BaseUnit> createMethod))
		{
			var unit = createMethod.Invoke();
			return unit;
		}
		else
		{
			Debug.LogWarning($"Unknown unit type: {unitName}");
			return null;
		}		
	}

	private static BaseUnit CreateFireElemental()
	{
		return ScriptableObject.CreateInstance("FireElemental") as FireElemental;
	}
}
