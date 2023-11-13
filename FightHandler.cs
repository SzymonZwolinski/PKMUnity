using asd;
using System.Linq;
using UnityEngine;

public static class FightHandler
{
	public static uint Turn = 1;

	public static void Attack(
		AttackModel playerAttack,
		BaseUnit playerUnit,
		BaseUnit enemyUnit)
	{
		var enemyAttack = GetEnemyAttack(enemyUnit, playerUnit);

		Debug.Log(enemyAttack);
		
		var enemyTurnDamage = CalculateAttackStats(
			enemyAttack, 
			enemyUnit,
			playerUnit,
			"enemy");
		enemyTurnDamage *= NatureWeaknessCalculator.CalculateDamageMultiplyer(
			enemyAttack.Type,
			playerUnit.FirstType,
			playerUnit.SecondaryType,
			enemyUnit.FirstType,
			enemyUnit.SecondaryType);
		
		var playerTurnDamage = CalculateAttackStats(
			playerAttack, 
			playerUnit, 
			enemyUnit,
			"player");
		playerTurnDamage *= NatureWeaknessCalculator.CalculateDamageMultiplyer(
			enemyAttack.Type, 
			enemyUnit.FirstType, 
			enemyUnit.SecondaryType,
			playerUnit.FirstType,
			playerUnit.SecondaryType);

		var executorOfFirstAttack = CalculateWhichAttackShouldBeFirstExecuted(
			enemyAttack, 
			playerAttack,
			playerUnit, 
			enemyUnit);

		if(executorOfFirstAttack == CharacterInBattleType.Player)
		{
			DealDamage(playerTurnDamage, enemyUnit);
			if(enemyUnit.HealthPoints > 0)
			{
				DealDamage(enemyTurnDamage, playerUnit);
			}
		}
		else
		{
			DealDamage(enemyTurnDamage, playerUnit);
			if (playerUnit.HealthPoints > 0)
			{
				DealDamage(playerTurnDamage, enemyUnit);
			}
		}

		Turn++;
		if(enemyUnit.HealthPoints <= 0 || playerUnit.HealthPoints <=0)
		{
			Turn = 1;
			SceneChanger.UnloadBattleScene();
		}
	}

	public static void EnemyOnlyAttack(BaseUnit enemyUnit, BaseUnit playerUnit)
	{
		var enemyAttack = GetEnemyAttack(enemyUnit, playerUnit);
		var enemyTurnDamage = CalculateAttackStats(
			enemyAttack, 
			enemyUnit,
			playerUnit,
			"enemy");

		DealDamage(enemyTurnDamage, playerUnit);
		Turn++;
	}

	private static void DealDamage(double damage, BaseUnit unitThatTakesDamage)
	{
		unitThatTakesDamage.HealthPoints -= damage;
	}

	private static AttackModel GetEnemyAttack(BaseUnit enemyUnit, BaseUnit playerUnit)
	{
		var chancesForMostOptimalAttack = Random.Range(0, 10);
		var attacks = enemyUnit.GetAllAttacks();

		return chancesForMostOptimalAttack > 3 ? 
			NatureWeaknessCalculator.GetMostOptimalAttack(
				enemyUnit, 
				playerUnit,
				attacks) :
			attacks.First();
	}

	private static CharacterInBattleType CalculateWhichAttackShouldBeFirstExecuted(
		AttackModel enemyAttack,
		AttackModel playerAttack,
		BaseUnit playerUnit,
		BaseUnit enemyUnit)
	{
		var enemySpeed = CalculateSpeed(enemyAttack, enemyUnit);
		var playerSpeed = CalculateSpeed(playerAttack, playerUnit);

		while(enemySpeed == playerSpeed)
		{
			enemySpeed += Random.Range(0, 10);
			playerSpeed += Random.Range(0, 10);
		}

		return enemySpeed > playerSpeed ?
			CharacterInBattleType.Enemy :
			CharacterInBattleType.Player;
	}

	private static double CalculateSpeed(AttackModel attack, BaseUnit unit)
	=> ((double)attack.Priority * 100) + (unit.Speed / 100);

	private static double CalculateAttackStats(
		AttackModel playerAttack,
		BaseUnit PlayerUnit,
		BaseUnit EnemyUnit,
		string who)
	{
		Debug.Log(who);
		var successfulAttack = CalculateAttackSuccess(playerAttack);

		if(!successfulAttack)
		{
			return (0); //successful = false
		}

		switch (playerAttack.Kind)
		{
			case AttackKind.Special:
				return CalculateSpecialDamage(
					playerAttack,
					PlayerUnit,
					EnemyUnit);
				

			case AttackKind.Physical:
				return CalculatePhysicalDamage(
					playerAttack,
					PlayerUnit, 
					EnemyUnit);

			default:
				return playerAttack.Damage;
		}
	}

	private static bool CalculateAttackSuccess(AttackModel attack)
	{
		var randomValue = Random.Range(0, 101);
		
		return attack.Accuracy == 100 ?
			true : 
			attack.Accuracy >= randomValue ?
				true :
				false;
	}

	private static double CalculateSpecialDamage(
		AttackModel attack,
		BaseUnit unit, 
		BaseUnit enemyUnit)
		=> (attack.Damage + (unit.SpecialAttack / 10) ) - enemyUnit.SpecialDefence > 0 ?
		(attack.Damage + (unit.SpecialAttack / 10)) - enemyUnit.SpecialDefence : 
		1;

	private static double CalculatePhysicalDamage(
		AttackModel attack,
		BaseUnit unit,
		BaseUnit enemyUnit)
		=> (attack.Damage + (unit.Attack / 10)) - enemyUnit.Defence > 0 ?
		(attack.Damage + (unit.Attack / 10)) - enemyUnit.Defence :
		1;
}
