
public static class NatureWeaknessCalculator
{
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

	#region WeaknessCalculator
	private static double GetWeaknessForEarthAttack(Types firstType, Types? secondType)
    {
		double damageMultiplyer = 1;
        switch(firstType) 
        {
            case Types.Wind:
				damageMultiplyer = 2;
				break;
			case Types.Earth:
				damageMultiplyer = 1;
				break;
            case Types.Fire:
				damageMultiplyer = 1;
				break;

			case Types.Water:
				damageMultiplyer = 0.5;
				break;

			default:
				damageMultiplyer = 1;
				break;
		}

		if(secondType != null)
		{
			switch (firstType)
			{
				case Types.Wind:
					damageMultiplyer += 2;
					break;
				case Types.Earth:
					damageMultiplyer += 1;
					break;
				case Types.Fire:
					damageMultiplyer += 1;
					break;

				case Types.Water:
					damageMultiplyer += 0.5;
					break;

				default:
					damageMultiplyer += 1;
					break;
			}
		}

		return damageMultiplyer;
    }

	private static double GetWeaknessForFireAttack(Types firstType, Types? secondType)
	{
		double damageMultiplyer = 1;

		switch (firstType)
		{
			case Types.Earth:
				damageMultiplyer = 2;
				break;
			case Types.Wind:
				damageMultiplyer = 1;
				break;
			case Types.Fire:
				damageMultiplyer = 1;
				break;

			case Types.Water:
				damageMultiplyer = 0.5;
				break;

			default:
				damageMultiplyer = 1;
				break;
		}

		if(secondType != null)
		{
			switch (firstType)
			{
				case Types.Earth:
					damageMultiplyer += 2;
					break;
				case Types.Wind:
					damageMultiplyer += 1;
					break;
				case Types.Fire:
					damageMultiplyer += 1;
					break;

				case Types.Water:
					damageMultiplyer += 0.5;
					break;

				default:
					damageMultiplyer += 1;
					break;
			}
		}

		return damageMultiplyer;
	}

	private static double GetWeaknessForWaterAttack(Types firstType, Types? secondType)
	{
		double damageMultiplyer = 1;

		switch (firstType)
		{
			case Types.Fire:
				damageMultiplyer = 2;
				break;
			case Types.Water:
				damageMultiplyer = 1;
				break;
			case Types.Earth:
				damageMultiplyer = 1;
				break;

			case Types.Wind:
				damageMultiplyer = 0.5;
				break;
			default:
				damageMultiplyer = 1;
				break;
		}

		if(secondType != null) 
		{
			switch (firstType)
			{
				case Types.Fire:
					damageMultiplyer += 2;
					break;
				case Types.Water:
					damageMultiplyer += 1;
					break;
				case Types.Earth:
					damageMultiplyer += 1;
					break;

				case Types.Wind:
					damageMultiplyer += 0.5;
					break;
				default:
					damageMultiplyer += 1;
					break;
			}
		}
		return damageMultiplyer;
	}

	private static double GetWeaknessForWindAttack(Types firstType, Types? secondType)
	{
		double damageMultiplyer = 1;

		switch (firstType)
		{
			case Types.Water:
				damageMultiplyer = 2;
				break;
			case Types.Fire:
				damageMultiplyer = 1;
				break;
			case Types.Wind:
				damageMultiplyer = 1;
				break;
			case Types.Earth:
				damageMultiplyer = 0.5;
				break;
			default:
				damageMultiplyer = 1;
				break;
		}

		if(secondType != null) 
		{
			switch (firstType)
			{
				case Types.Water:
					damageMultiplyer += 2;
					break;
				case Types.Fire:
					damageMultiplyer += 1;
					break;
				case Types.Wind:
					damageMultiplyer += 1;
					break;
				case Types.Earth:
					damageMultiplyer += 0.5;
					break;
				default:
					damageMultiplyer += 1;
					break;
			}
		}

		return damageMultiplyer;
	}
	#endregion
}
