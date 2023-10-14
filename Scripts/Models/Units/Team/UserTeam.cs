using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserTeam : MonoBehaviour
{
	private readonly short MaxTeamSize = 5; // = 6 bcs list is iterating from 0

	public List<BaseUnit> Team = new List<BaseUnit>();
	public List<BaseUnit> Storage = new List<BaseUnit>();

	public void AddToTeamOrStorage(BaseUnit unit)
	{
		if(Team.Count > MaxTeamSize)
		{
			Storage.Add(unit);
			return;
		}

		Team.Add(unit);
		Debug.Log(Team.Count);
	}

	public void RemoveFromTeam(BaseUnit unit)
	{
		var unitInTeam = Team.FirstOrDefault(x => x.Equals(unit));

		if (unitInTeam == default)
		{
			return;
		}

		try
		{
			Team.Remove(unitInTeam);
		}
		catch
		{
		}
	}

	public void MoveToStorageFromTeam(BaseUnit unit)
	{
		var unitInTeam = Team.FirstOrDefault(x => x.Equals(unit));

		if(unitInTeam == default) 
		{
			return;
		}

		try
		{
			Storage.Add(unitInTeam);
			Team.Remove(unitInTeam);
		}
		catch 
		{

			Debug.Log("error while moving to storage");
		}
	}

	public void MoveToTeamFromStorage(BaseUnit unit)
	{
		var unitInStorage = Storage.FirstOrDefault(x => x.Equals(unit));

		if(Team.Count >= MaxTeamSize)
		{
			return; // MaxTeamCount is 6, Add some info for user
		}

		if(unitInStorage == default) 
		{ 
			return;
		}

		try
		{
			Team.Add(unitInStorage);
			Storage.Remove(unitInStorage);
		}
		catch
		{

		}
	}

	public void RemoveFromStorage(BaseUnit unit)
	{
		var unitInStorage = Storage.FirstOrDefault(x => x.Equals(unit));

		if(unitInStorage == default)
		{
			return;
		}

		try
		{
			Storage.Remove(unitInStorage);
		}
		catch 
		{ 
		}
	}

}
