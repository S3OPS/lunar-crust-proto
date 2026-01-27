using UnityEngine;
using MiddleEarth.Config;

[System.Serializable]
public class CharacterStats
{
    public string characterName = "Aragorn";
    public int level = 1;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public int strength = 10;
    public int wisdom = 10;
    public int agility = 10;
    public int experience = 0;
    public int experienceToNextLevel = 100;

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0f, currentHealth - damage);
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }

    public void UseStamina(float amount)
    {
        currentStamina = Mathf.Max(0f, currentStamina - amount);
    }

    public void RestoreStamina(float amount)
    {
        currentStamina = Mathf.Min(maxStamina, currentStamina + amount);
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        while (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        experience -= experienceToNextLevel;
        experienceToNextLevel = (int)(experienceToNextLevel * GameConstants.XP_SCALING_FACTOR);
        
        maxHealth += GameConstants.LEVELUP_HEALTH_BONUS;
        currentHealth = maxHealth;
        maxStamina += GameConstants.LEVELUP_STAMINA_BONUS;
        currentStamina = maxStamina;
        strength += GameConstants.LEVELUP_STAT_INCREASE;
        wisdom += GameConstants.LEVELUP_STAT_INCREASE;
        agility += GameConstants.LEVELUP_STAT_INCREASE;
        
        Debug.Log($"🎉 LEVEL UP! You are now level {level}!");
        
        // Visual and audio feedback
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayLevelUpSound();
        }
        
        if (AchievementSystem.Instance != null)
        {
            AchievementSystem.Instance.OnLevelUp(level);
        }
    }
}
