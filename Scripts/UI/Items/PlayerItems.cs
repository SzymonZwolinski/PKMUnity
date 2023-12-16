using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<ItemBase> items = new List<ItemBase>();
    private int CurrentItem = 0;

    public void AddItem(ItemBase item)
    {
        if(items.Any(x => x.name == item.name))
        {
            items.First(x=> x.name == item.name).AddQuantity();
        }

        items.Add(item);
    }

    public void TryToRemoveItem(ItemBase item)
    {
        if(items.Any(x => x.name == item.name))
        {
            if(items.First(x=> x.name == item.Name).Quantity == 0)
            {
                items.Remove(item);
            }
        }
    }

    public ItemBase NextItem()
    {
        if(items.Count == 0)
        {
            return null;
        }

        if(CurrentItem+1 > items.Count)
        {
            CurrentItem = 0;
        }
        else
        {
            CurrentItem++;
        }

        return items[CurrentItem];
	}

    public ItemBase PreviousItem()
    {
		if (items.Count == 0)
		{
			return null;
		}

		if (CurrentItem == 0)
		{
			CurrentItem = items.Count-1;
		}
		else
		{
			CurrentItem--;
		}

		return items[CurrentItem];
	}

    public ItemBase GetFirstItem()
     => items.FirstOrDefault();

    public void UseItem(BaseUnit unit)
    {
        items[CurrentItem].TryToUseItem(unit);
    }
}
