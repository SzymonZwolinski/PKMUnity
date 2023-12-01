
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class NatureWeaknessCalculator
{
	public static AttackModel GetMostOptimalAttack(
		BaseUnit enemyUnit,
		BaseUnit playerUnit,
		List<AttackModel> attacks)
	{
		var mostOptimalAttacks = new List<AttackModel>();
		AddAttacksBasedOnType(enemyUnit.FirstType, attacks, mostOptimalAttacks);
		
		if (enemyUnit.SecondaryType != null)
		{
			AddAttacksBasedOnType(
				(Types)enemyUnit.SecondaryType,
				attacks,
				mostOptimalAttacks);
		}

		if (!mostOptimalAttacks.Any())
		{
			return playerUnit.Attack > playerUnit.SpecialAttack ?
				GetAttack(attacks, AttackKind.Physical) :
				GetAttack(attacks, AttackKind.Special);
		}

		return playerUnit.Attack > playerUnit.SpecialAttack ?
				GetAttack(mostOptimalAttacks, AttackKind.Physical) :
				GetAttack(mostOptimalAttacks, AttackKind.Special);
	}

	private static void AddAttacksBasedOnType(
		Types type,
		List<AttackModel> attacks,
		List<AttackModel> mostOptimalAttacks)
	{
		switch (type)
		{
			case Types.Earth:
				mostOptimalAttacks.AddRange(attacks.Where(x => x.Type == Types.Fire));
				break;
			case Types.Fire:
				mostOptimalAttacks.AddRange(attacks.Where(x => x.Type == Types.Water));
				break;
			case Types.Wind:
				mostOptimalAttacks.AddRange(attacks.Where(x => x.Type == Types.Earth));
				break;
			case Types.Water:
				mostOptimalAttacks.AddRange(attacks.Where(x => x.Type == Types.Wind));
				break;
		}
	}

	private static AttackModel GetAttack(List<AttackModel> attacks, AttackKind attackKind)
	{
		var attack = attacks.OrderBy(x => x.Damage).FirstOrDefault(x => x.Kind == attackKind);

		return attack is null ?
			attack :
			attacks.OrderBy(x => x.Damage)
			.FirstOrDefault();
	}

	public static double CalculateDamageMultiplyer(
		Types attackType,
		Types firstEnemyType,
		Types? secondaryEnemyType,
		Types firstAllyType,
		Types? secondaryAllyType
	   )
	{
		double damageMultiplyer = 1;

		switch (attackType)
		{
			case Types.Earth:
				damageMultiplyer = GetWeaknessForEarthAttack(firstEnemyType, secondaryEnemyType);
				break;
			case Types.Fire:
				damageMultiplyer = GetWeaknessForFireAttack(firstEnemyType, secondaryEnemyType);
				break;
			case Types.Wind:
				damageMultiplyer = GetWeaknessForWindAttack(firstEnemyType, secondaryEnemyType);
				break;
			case Types.Water:
				damageMultiplyer = GetWeaknessForWaterAttack(firstEnemyType, secondaryEnemyType);
				break;
		}

		if (attackType == firstAllyType || attackType == secondaryAllyType)
		{
			damageMultiplyer += 1.5;
		}

		return damageMultiplyer;
    }

	private static double GetWeaknessForAttack(Types firstType, Types? secondType, Dictionary<Types, double> weaknesses)
	{
		double damageMultiplier = 1;

		if (weaknesses.TryGetValue(firstType, out double firstTypeMultiplier))
		{
			damageMultiplier = firstTypeMultiplier;
		}

		if (secondType != null && weaknesses.TryGetValue(secondType.Value, out double secondTypeMultiplier))
		{
			damageMultiplier += secondTypeMultiplier;
		}

		return damageMultiplier;
	}
	#region weaknesses
	private static double GetWeaknessForEarthAttack(Types firstType, Types? secondType)
	{
		var weaknesses = new Dictionary<Types, double>
	{
		{ Types.Wind, 2 },
		{ Types.Earth, 1 },
		{ Types.Fire, 1 },
		{ Types.Water, 0.5 }
	};

		return GetWeaknessForAttack(firstType, secondType, weaknesses);
	}

	private static double GetWeaknessForFireAttack(Types firstType, Types? secondType)
	{
		var weaknesses = new Dictionary<Types, double>
	{
		{ Types.Earth, 2 },
		{ Types.Wind, 1 },
		{ Types.Fire, 1 },
		{ Types.Water, 0.5 }
	};

		return GetWeaknessForAttack(firstType, secondType, weaknesses);
	}

	private static double GetWeaknessForWaterAttack(Types firstType, Types? secondType)
	{
		var weaknesses = new Dictionary<Types, double>
	{
		{ Types.Wind, 2 },
		{ Types.Water, 1 },
		{ Types.Earth, 1 },
		{ Types.Fire, 0.5 }
	};

		return GetWeaknessForAttack(firstType, secondType, weaknesses);
	}

	private static double GetWeaknessForWindAttack(Types firstType, Types? secondType)
	{
		var weaknesses = new Dictionary<Types, double>
	{
		{ Types.Earth, 2 },
		{ Types.Fire, 1 },
		{ Types.Wind, 1 },
		{ Types.Water, 0.5 }
	};

		return GetWeaknessForAttack(firstType, secondType, weaknesses);
	}

	#endregion
}
