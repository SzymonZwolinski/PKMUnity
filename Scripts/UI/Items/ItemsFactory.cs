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

	public static ItemBase GetItem(Items itemName)
	{
		if (unitInitDelegates.TryGetValue(itemName, out Func<ItemBase> createMethod))
		{
			var unit = createMethod.Invoke();
			return unit;
		}
		else
		{
			Debug.LogWarning($"Unknown item type: {itemName}");
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
