using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUnitsButtonsHandler : MonoBehaviour
{
   public void MoveUnitUp(int UnitToMoveActualPosition)
	{
		var UnitNewPosition = UnitToMoveActualPosition - 1;

		if(UnitNewPosition > 0) 
		{
			var player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponentInChildren<UserTeam>()
				.MoveUnitInTeamToIntendedPosition(UnitToMoveActualPosition, UnitNewPosition);

			player.GetComponentInChildren<TeamHandler>()
				.RefrestTeamPanel();
			
		}
	}

	public void MoveUnitDown(int UnitToMoveActualPosition)
	{
		var UnitNewPosition = UnitToMoveActualPosition + 1;

		if (UnitNewPosition < 6)
		{
			var player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponentInChildren<UserTeam>()
				.MoveUnitInTeamToIntendedPosition(UnitToMoveActualPosition, UnitNewPosition);

			player.GetComponentInChildren<TeamHandler>()
				.RefrestTeamPanel();

		}
	}
}
