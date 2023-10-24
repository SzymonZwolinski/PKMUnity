using UnityEngine;

public static class CaptureEnemy 
{
    private static int CurrentAmountOfTries;

    public static bool TryToCapture(BaseUnit playerUnit, BaseUnit enemyUnit)
    {
        var unitLevelDiff = (int)(playerUnit.Level - enemyUnit.Level);
        var isSuccess = false;

        switch (unitLevelDiff)
        {
            case > 5:
                isSuccess = CalculateChanceForMoreThan(unitLevelDiff, enemyUnit);
                break;

            case <= 5:
                isSuccess = CalculateChanceForEqual(enemyUnit);
                break;
        }

        if (isSuccess) 
        {
            GameObject.FindGameObjectWithTag("Player")
                .GetComponentInChildren<UserTeam>()
                .AddToTeamOrStorage(enemyUnit);
            CurrentAmountOfTries = 0;
            return isSuccess;
        }

        CurrentAmountOfTries++;
        return isSuccess;
    }

    private static bool CalculateChanceForMoreThan(int levelDiff, BaseUnit enemyUnit)
    {
        var firstRandomNumber = Random.Range(0, 255);
        var secondRandomNumber = Random.Range(0, 255);

        return Mathf.Abs(((enemyUnit.MaxHealthPoints + firstRandomNumber) *
            (secondRandomNumber + CurrentAmountOfTries)) /
            ((enemyUnit.HealthPoints + levelDiff) * 
            Mathf.Abs(CurrentAmountOfTries))) > 1;
    }

    private static bool CalculateChanceForEqual(BaseUnit enemyUnit) 
    {
		var firstRandomNumber = Random.Range(0, 255);
		var secondRandomNumber = Random.Range(0, 255);

        return Mathf.Abs(((enemyUnit.MaxHealthPoints + firstRandomNumber) *
            (secondRandomNumber + CurrentAmountOfTries)) /
            ((enemyUnit.HealthPoints) * Mathf.Abs(CurrentAmountOfTries))) > 1;
	}
}
