using System;

public abstract class ItemBase 
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Value => _value * Quantity;
	protected float _value { get; set; }
    public uint Quantity { get; private set; }
    public float SellValue { get; private set; }
    public byte[] Icon {get; private set; }

    public ItemBase(
        string name,
        string description, 
        float value, 
        uint quantity,
        byte[] icon)
    {
        Id = Guid.NewGuid();
		Name = name;
        Description = description;
        Quantity = quantity;
        SetValue(value);
        Icon = icon;
	}

    protected void SetValue(float value)
    {
		_value = MathF.Round(value,2);
	}
}
