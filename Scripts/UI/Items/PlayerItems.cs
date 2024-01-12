using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<ItemBase> Items = new List<ItemBase>();
    private int CurrentItem = 0;

    public void AddItem(ItemBase item)
    {
        if(Items.Any(x => x.name == item.name))
        {
            Items.First(x=> x.name == item.name).AddQuantity();
        }

        Items.Add(item);
    }

    public void TryToRemoveItem(ItemBase item)
    {
        if(Items.Any(x => x.name == item.name))
        {
            if(Items.First(x=> x.name == item.Name).Quantity == 0)
            {
                Items.Remove(item);
            }
        }
    }

    public ItemBase NextItem()
    {
        if(Items.Count == 0)
        {
            return null;
        }

        if(CurrentItem+1 > Items.Count)
        {
            CurrentItem = 0;
        }
        else
        {
            CurrentItem++;
        }

        return Items[CurrentItem];
	}

    public ItemBase PreviousItem()
    {
		if (Items.Count == 0)
		{
			return null;
		}

		if (CurrentItem == 0)
		{
			CurrentItem = Items.Count-1;
		}
		else
		{
			CurrentItem--;
		}

		return Items[CurrentItem];
	}

    public ItemBase GetFirstItem()
     => Items.FirstOrDefault();

    public void UseItem(BaseUnit unit)
    {
        Items[CurrentItem].TryToUseItem(unit);
    }
}
