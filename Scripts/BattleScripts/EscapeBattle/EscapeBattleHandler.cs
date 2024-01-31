using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EscapeBattleHandler : MonoBehaviour
{
    private BaseUnit CurrentPlayerUnit;

	private void OnEnable()
	{
		var userTeam = GameObject
		.FindGameObjectWithTag("Player")
		.GetComponentInChildren<UserTeam>();

		CurrentPlayerUnit = userTeam.Team.FirstOrDefault();
	}

	public void HasUserEscaped()
    {
		var enemy = GameObject
			.FindGameObjectWithTag("Enemy")
			.GetComponent<UnitTypeMarker>()
			.UnitType;

		EscapeBattle.HasPlayerEscaped(CurrentPlayerUnit, enemy);
    }
}
