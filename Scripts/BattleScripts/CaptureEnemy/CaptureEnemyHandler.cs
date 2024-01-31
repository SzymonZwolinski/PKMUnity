using asd;
using System.Linq;
using UnityEngine;

public class CaptureEnemyHandler : MonoBehaviour
{
	private BaseUnit CurrentPlayerUnit;

	private void OnEnable()
	{
		var userTeam = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<UserTeam>();

		CurrentPlayerUnit = userTeam.Team.FirstOrDefault();
	}

	public void TryToCaptureEnemy()
	{
		var enemy = GameObject
			.FindGameObjectWithTag("Enemy")
			.GetComponent<UnitTypeMarker>()
			.UnitType;

		var isCaptured = CaptureEnemy.TryToCapture(CurrentPlayerUnit, enemy);

		if(isCaptured)
		{
			SceneChanger.UnloadBattleScene();
			return;
		}

		FightHandler.EnemyOnlyAttack(enemy, CurrentPlayerUnit); // If we fail to capture enemy should be still able to use its ability
	}
}
