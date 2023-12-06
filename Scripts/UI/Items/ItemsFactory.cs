using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemsFactory 
{
	
	private static Dictionary<Items, Func<ItemBase>> unitInitDelegates = new()
	{
		{ Items.Apple, CreateApple },
	};

	public static ItemBase GetUnit(Items itemName)
	{
		if (unitInitDelegates.TryGetValue(itemName, out Func<ItemBase> createMethod))
		{
			var unit = createMethod.Invoke();
			return unit;
		}
		else
		{
			Debug.LogWarning($"Unknown unit type: {itemName}");
			return null;
		}
	}

	private static ItemBase CreateApple()
	{
		var item = ScriptableObject.CreateInstance("Apple") as Apple;

		item.Init();
		return item;
	}
}
