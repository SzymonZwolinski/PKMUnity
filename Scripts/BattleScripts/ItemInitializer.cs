using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ItemInitializer
{
    public static ItemBase OneOrNoneItemFromList(IEnumerable<Items> availibleItems)
    {
        var asd = Random.Range(0, availibleItems.Count()+1);

        if((availibleItems.Count()  -1) < asd )
        {
            return null;
        }

        return ItemsFactory.GetItem(availibleItems.ElementAt(asd));
    }
}
