using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireElemental : BaseUnit
{
	public FireElemental(
		int healthPoints,
		uint attack,
		uint specialAttack,
		uint defence,
		uint specialDefence,
		uint speed,
		uint stamina,
		bool isAlive,
		Types firstType,
		Types? secondaryType,
		uint level,
		float baseExperiencePointsToNextLevel,
		float experiencePointsToNextLevel,
		float experiencePoints,
		uint healthPointsLearned,
		uint attackLearned,
		uint specialAttackLearned,
		uint defenceLearned,
		uint specialDefenceLearned,
		uint speedLearned,
		uint staminaLearned,
		bool hasBeenSeen,
		bool hasBeenCaught,
		HoldItem heldItem,
		float experiencePointsWorth,
		float experiencePointsRequirementMultiplier,
		uint spawnRate,
		string prefabPath)
		: base(
			healthPoints,
			attack,
			specialAttack,
			defence,
			specialDefence,
			speed,
			stamina,
			isAlive,
			firstType,
			secondaryType,
			level,
			baseExperiencePointsToNextLevel,
			experiencePointsToNextLevel,
			experiencePoints,
			healthPointsLearned,
			attackLearned,
			specialAttackLearned,
			defenceLearned,
			specialDefenceLearned,
			speedLearned,
			staminaLearned,
			hasBeenSeen,
			hasBeenCaught,
			heldItem,
			experiencePointsWorth,
			experiencePointsRequirementMultiplier,
			spawnRate,
			prefabPath)
	{
		HealthPoints = 100;
		Attack = 10;
		SpecialAttack = 10;
		Defence = 10;
		SpecialDefence = 10;
		Speed = 10;
		Stamina = 100;
		IsAlive = true;
		FirstType = Types.Fire;
		SecondaryType = null;
		Level = 5;
		BaseExperiencePointsToNextLevel = 100;
		ExperiencePointsToNextLevel = BaseExperiencePointsToNextLevel;
		ExperiencePoints = 0;
		HealthPointsLearned = 0;
		AttackLearned = 0;
		SpecialAttackLearned = 0;
		DefenceLearned = 0;
		SpecialDefenceLearned = 0;
		SpeedLearned = 0;
		StaminaLearned = 0;
		HasBeenSeen = true;
		HasBeenCaught = false;
		HeldItem = null;
		ExperiencePointsWorth = 10;
		ExperiencePointsRequirementMultiplier = 1.1f;
		SpawnRate = spawnRate;
		PrefabPath = prefabPath;
	}

	public FireElemental()
	{
		Name = nameof(FireElemental);
		MaxHealthPoints = 100;
		HealthPoints = 100;
		Attack = 10;
		SpecialAttack = 10;
		Defence = 10;
		SpecialDefence = 10;
		Speed = 10;
		Stamina = 100;
		IsAlive = true;
		FirstType = Types.Fire;
		SecondaryType = Types.Water;
		Level = 5;
		BaseExperiencePointsToNextLevel = 100;
		ExperiencePointsToNextLevel = BaseExperiencePointsToNextLevel;
		ExperiencePoints = 0;
		HealthPointsLearned = 0;
		AttackLearned = 0;
		SpecialAttackLearned = 0;
		DefenceLearned = 0;
		SpecialDefenceLearned = 0;
		SpeedLearned = 0;
		StaminaLearned = 0;
		HasBeenSeen = true;
		HasBeenCaught = false;
		HeldItem = null;
		ExperiencePointsWorth = 10;
		ExperiencePointsRequirementMultiplier = 1.1f;
		FirstAttack = null;
		SecondAttack = AttacsFactory.GetAttack("MagicBolt");
		ThirdAttack = null;
		FourthAttack = null;
		AvailibleAttacks = new List<string> { "_", "_", "MagicBolt", "_" };
		SpawnRate = 1;
		PrefabPath = "Slime_02";
	}
}
