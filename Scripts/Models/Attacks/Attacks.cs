using System.Collections.Generic;

public static class Attacks 
{
	public static AttackModel GetAttack(string attackName)
	{
		if (abilities.ContainsKey(attackName))
		{
			return abilities[attackName];
		}
		else { return abilities["_"]; }
	}

	public static Dictionary<string, AttackModel> abilities { get; set; } = new Dictionary<string, AttackModel>
	{
		{ "_", new AttackModel( "Dziab", 5, 90, Types.Earth, AttackPriority.Slowest, null, AttackKind.Physical)},
		{ "Bite", new AttackModel("Bite", 25, 100, Types.Earth, AttackPriority.Normal, null, AttackKind.Physical) },
		{ "MagicBolt", new AttackModel("MagicBolt", 15, 100, Types.Fire ,AttackPriority.Fast, null, AttackKind.Special) },
		{ "Poison", new AttackModel("Poison", 0, 100, Types.Earth, AttackPriority.Normal, AttackStatus.Poison, AttackKind.Status) }
    };
}
