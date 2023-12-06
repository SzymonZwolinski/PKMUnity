
using UnityEngine;

[CreateAssetMenu]
public class Apple : ItemBase
{

    public Apple()
    {
        
    }

    public override void UseItem(BaseUnit unit)
	{
		if (Quantity > 0)
		{
			unit.Heal(25);
			Quantity--;
		}	
	}

	public void Init()
	{
		Name = nameof(Apple);
		Description = "Heal unit by 25";
		Quantity = Quantity == 0 ? 1 : Quantity++;
		SetValue(25);
	}
}
