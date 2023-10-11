using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
	//Enemy
	public Text EnemyName;
	public Text EnemyHealthPoints;

	/*//User
	public Text Name;
	public Text HealthPoints;
	public Button FirstMove;
	public Button SecondMove;
	public Button ThirdMove;
	public Button FourthMove;*/

	void OnEnable()
	{
		var enemy = GameObject.FindGameObjectWithTag("Enemy");
		//var userTeam = GameObject.FindGameObjectsWithTag("Ally");

		InitalizeEnemyPanel(enemy);
	}

	private void InitalizeEnemyPanel(GameObject enemy)
	{
		var enemyStats = enemy.GetComponent<StatHolder>().UnitStats;
		EnemyName.text = enemyStats.Name;
		EnemyHealthPoints.text = $"{enemyStats.HealthPoints}/{enemyStats.MaxHealthPoints}";
	}
}
