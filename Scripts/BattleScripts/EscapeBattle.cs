using asd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EscapeBattle 
{
	private static int CurrentAmountOfTries = 1;
	public static bool HasPlayerEscaped(BaseUnit playerUnit, BaseUnit enemyUnit)
	{
		var unitLevelDiff = (int)(playerUnit.Level - enemyUnit.Level);
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
			SceneChanger.UnloadBattleScene();
			return true;
		}

		FightHandler.EnemyOnlyAttack(enemyUnit, enemyUnit);
		return false;
	}

	private static bool HasRunSuccededForGreater()
		=> Random.Range(0, 15) > 7;

	private static bool HasRunSuccededForEqual()
		=> Random.Range(0, 11) < 7;
}
