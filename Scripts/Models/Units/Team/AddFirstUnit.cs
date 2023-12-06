using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AddFirstUnit 
{
   public static void AddFirstUnitToPlayerTeam()
	{
		var userTeam = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<UserTeam>();

		var firstUnit = PrepareFirstUnit();

		userTeam.AddToTeamOrStorage(firstUnit);
	}

	private static BaseUnit PrepareFirstUnit()
	{
		return new FirstTestUnit();
	}
}
