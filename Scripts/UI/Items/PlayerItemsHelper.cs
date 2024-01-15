using UnityEngine;

namespace Assets.Scripts.UI.Items
{
    public static class PlayerItemsHelper
    {
        public static void TryToAddItemsToPlayerForDefeatedUnit(BaseUnit unit)
        {
            var item = unit.CheckIfAnyItemCouldBeDropped();

            if (item != null) 
            {
                var playerItems = GameObject
                    .FindGameObjectWithTag("Player")
                    .GetComponentInChildren<PlayerItems>();

                playerItems.AddItem(item);
            }
        }
    }
}
