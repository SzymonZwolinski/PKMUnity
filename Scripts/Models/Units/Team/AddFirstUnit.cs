using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFirstUnit : MonoBehaviour
{
   public void AddFirstUnitToPlayerTeam()
	{
		var userTeam = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<UserTeam>();

		var firstUnit = PrepareFirstUnit();

		Debug.Log(userTeam);

		userTeam.AddToTeamOrStorage(firstUnit);
	}

	private BaseUnit PrepareFirstUnit()
	{
		return new FirstTestUnit();
	}
}
