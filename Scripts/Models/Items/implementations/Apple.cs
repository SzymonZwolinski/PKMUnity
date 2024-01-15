
using UnityEngine;

[CreateAssetMenu]
public class Apple : ItemBase
{

    public Apple()
    {
        
    }

    public override bool TryToUseItem(BaseUnit unit)
	{
		if (Quantity > 0)
		{
			unit.Heal(25);
			Quantity--;

			return true;
		}	

		return false;
	}

	public void Init()
	{
		Name = nameof(Apple);
		Description = "Heal unit by 25";
		Quantity = 1;
		SetValue(25);
	}
}
