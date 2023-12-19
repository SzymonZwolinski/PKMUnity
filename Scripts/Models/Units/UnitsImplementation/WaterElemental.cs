
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaterElemental : BaseUnit
{
	
	public WaterElemental(
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
			experiencePointsWorth, 
			experiencePointsRequirementMultiplier,
			spawnRate,
			prefabPath)
	{
		HealthPoints = 100;
		Attack = 10;
		SpecialAttack = 5;
		Defence = 8;
		SpecialDefence = 12;
		Speed = 15;
		Stamina = 100;
		IsAlive = true;
		FirstType = Types.Water;
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
		ExperiencePointsWorth = 10;
		ExperiencePointsRequirementMultiplier = 1.1f;
		SpawnRate = spawnRate;
		PrefabPath = prefabPath;
	}

	public WaterElemental()
	{
		Name = nameof(WaterElemental);
		MaxHealthPoints = 100;
		HealthPoints = 100;
		Attack = 10;
		SpecialAttack = 10;
		Defence = 10;
		SpecialDefence = 10;
		Speed = 10;
		Stamina = 100;
		IsAlive = true;
		FirstType = Types.Water;
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
		ExperiencePointsWorth = 10;
		ExperiencePointsRequirementMultiplier = 1.1f;
		FirstAttack = AttacsFactory.GetAttack("Bite");
		SecondAttack = null;
		ThirdAttack = null;
        FourthAttack = null;
		AvailibleAttacks = new List<string> { "_", "Bite", "MagicBolt", "Poison" };
		AvailibleItems = new List<Items> { Items.Apple };
		SpawnRate = 1;
		PrefabPath = "Slime_03 Leaf";
	}

    public override ItemBase CheckIfAnyItemCouldBeDropped()
       => ItemInitializer.OneOrNoneItemFromList(AvailibleItems);

    protected override void ImproveStats()
    {
        HealthPointsLearned += 10;
        AttackLearned += 2;
        SpecialAttackLearned += 2;
        DefenceLearned += 2;
        SpecialDefenceLearned += 2;
        SpeedLearned += 2;
        StaminaLearned += 2;

        MaxHealthPoints += HealthPointsLearned;
        HealthPoints += MaxHealthPoints;
        Attack += AttackLearned;
        SpecialAttack += SpecialAttackLearned;
        Defence += DefenceLearned;
        SpecialDefence += SpecialDefenceLearned;
        Speed += SpeedLearned;
        Stamina += StaminaLearned;

		if(Level == 5)
		{
			SecondAttack = AttacsFactory.GetAttack("MagicBolt");
		}
    }
}
