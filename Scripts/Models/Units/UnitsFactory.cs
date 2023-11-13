using System.Collections.Generic;

public static class UnitsFactory
{
	public static BaseUnit GetUnit(UnitNames unitName)
	{
		if (units.ContainsKey(unitName))
		{
			return units[unitName];
		}
		return null;
	}

	public static Dictionary<UnitNames, BaseUnit> units { get; set; } = new Dictionary<UnitNames, BaseUnit>
	{
		{ UnitNames.FireElemental, new FireElemental()},
	};
}
