using System;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public float Value => _value * Quantity;
	protected float _value { get; set; }    
    public uint Quantity { get; protected set; }

    protected void SetValue(float value)
    {
		_value = MathF.Round(value,2);
	}

    public abstract void UseItem(BaseUnit unit);

    public void AddQuantity()
    {
        Quantity++;
    }
}
