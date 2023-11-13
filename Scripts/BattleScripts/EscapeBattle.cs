using asd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EscapeBattle 
{
	private static int CurrentAmountOfTries = 0;
	public static bool HasPlayerEscaped(BaseUnit playerUnit, BaseUnit enemyUnit)
	{
		var unitLevelDiff = playerUnit.Level - enemyUnit.Level;
		var isSuccess = false;

		switch (unitLevelDiff) 
		{
			case > 5:
				isSuccess = HasRunSuccededForGreater();
				break;
			case <= 5:
				isSuccess = HasRunSuccededForEqual();
				break;
		}

		if (isSuccess)
		{
			CurrentAmountOfTries = 0;
			SceneChanger.UnloadBattleScene();
			return true;
		}

		CurrentAmountOfTries++;
		FightHandler.EnemyOnlyAttack(enemyUnit, playerUnit);
		return false;
	}

	private static bool HasRunSuccededForGreater()
		=> Random.Range(0, 21) >= 10;

	private static bool HasRunSuccededForEqual()
		=> (Random.Range(0, 21) + CurrentAmountOfTries) >= 10;
}
