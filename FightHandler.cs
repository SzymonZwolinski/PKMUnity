using asd;
using System.Text;
using UnityEngine;

public static class FightHandler
{
	private static uint Turn = 1;

	public static void Attack(
		AttackModel playerAttack,
		BaseUnit playerUnit,
		BaseUnit enemyUnit)
	{
		var enemyAttack = GetEnemyAttack(enemyUnit);
		var enemyTurnDamage = CalculateAttackStats(playerAttack, enemyUnit);

		var playerTurnDamage = CalculateAttackStats(playerAttack, playerUnit);

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

		Debug.Log("tura" + Turn);

		Turn++;
		if(enemyUnit.HealthPoints <= 0)
		{
			Turn = 1;
			SceneChanger.UnloadBattleScene();
		}
	}  

	private static void DealDamage(uint damage, BaseUnit unitThatTakesDamage)
	{
		unitThatTakesDamage.HealthPoints -= damage;
	}

	private static AttackModel GetEnemyAttack(BaseUnit enemyUnit)
	{
		return 
			enemyUnit.FirstAttack ??
			enemyUnit.SecondAttack ??
			enemyUnit.ThirdAttack ??
			enemyUnit.FourthAttack;
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

		return enemySpeed > playerSpeed ? CharacterInBattleType.Enemy : CharacterInBattleType.Player;
	}

	private static long CalculateSpeed(AttackModel attack, BaseUnit unit)
	=> ((int)attack.Priority * 100) + (unit.Speed / 100);

	private static uint CalculateAttackStats(AttackModel playerAttack,	BaseUnit PlayerUnit)
	{
		
		var successfulAttack = CalculateAttackSuccess(playerAttack);

		if(!successfulAttack)
		{
			return (0); //successful = false
		}

		switch (playerAttack.Kind)
		{
			case AttackKind.Special:
				return CalculateSpecialDamage(playerAttack, PlayerUnit);
				

			case AttackKind.Physical:
				return CalculatePhysicalDamage(playerAttack, PlayerUnit);

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

	private static uint CalculateSpecialDamage(AttackModel attack, BaseUnit unit)
		=> attack.Damage + (unit.SpecialAttack / 10);

	private static uint CalculatePhysicalDamage(AttackModel attack, BaseUnit unit)
		=> attack.Damage + (unit.Attack / 10);
}
