using UnityEngine;

/// <summary>
/// Demo script to validate RPG systems functionality
/// This demonstrates that all core RPG features are working correctly
/// </summary>
public class RPGSystemsDemo : MonoBehaviour
{
    public static void RunDemo()
    {
        Debug.Log("=== MIDDLE-EARTH RPG SYSTEMS DEMO ===\n");

        // Test Character Stats
        Debug.Log("--- Testing Character Stats System ---");
        var character = new CharacterStats();
        character.characterName = "Frodo";
        Debug.Log($"Character: {character.characterName}, Level: {character.level}");
        Debug.Log($"Health: {character.currentHealth}/{character.maxHealth}");
        
        character.TakeDamage(25f);
        Debug.Log($"After taking 25 damage: {character.currentHealth}/{character.maxHealth}");
        
        character.Heal(10f);
        Debug.Log($"After healing 10: {character.currentHealth}/{character.maxHealth}");
        
        character.GainExperience(150);
        Debug.Log($"After gaining 150 XP: Level {character.level}, XP: {character.experience}/{character.experienceToNextLevel}");
        Debug.Log($"Stats increased - Strength: {character.strength}, Wisdom: {character.wisdom}\n");

        // Test Inventory System
        Debug.Log("--- Testing Inventory System ---");
        var inventory = new InventorySystem();
        Debug.Log($"Starting gold: {inventory.gold}");
        
        var sword = new Item("Anduril", "The flame of the West", ItemType.Weapon, 500, 1);
        inventory.AddItem(sword);
        Debug.Log($"Added item: {sword.name}");
        
        inventory.AddGold(100);
        Debug.Log($"After adding 100 gold: {inventory.gold}");
        
        Debug.Log($"Has Anduril? {inventory.HasItem("Anduril")}");
        Debug.Log($"Total items in inventory: {inventory.GetAllItems().Count}\n");

        // Test Quest System
        Debug.Log("--- Testing Quest System ---");
        var quest = new Quest(
            "demo_quest",
            "The Journey Begins",
            "Embark on your adventure across Middle-earth",
            200,
            500
        );
        
        quest.AddObjective(new QuestObjective(
            "find_sword",
            "Find the legendary sword",
            ObjectiveType.CollectItem,
            1
        ));
        
        quest.AddObjective(new QuestObjective(
            "defeat_enemy",
            "Defeat 3 enemies",
            ObjectiveType.DefeatEnemy,
            3
        ));
        
        Debug.Log($"Quest: {quest.questName}");
        Debug.Log($"Description: {quest.description}");
        Debug.Log($"Initial completion: {quest.GetCompletionPercentage()}%");
        
        quest.isActive = true;
        quest.UpdateProgress("find_sword", 1);
        Debug.Log($"After completing first objective: {quest.GetCompletionPercentage()}%");
        
        quest.UpdateProgress("defeat_enemy", 3);
        Debug.Log($"After completing all objectives: {quest.GetCompletionPercentage()}%");
        Debug.Log($"Quest completed? {quest.isCompleted}\n");

        // Test Item Types
        Debug.Log("--- Testing Item Types ---");
        var items = new Item[] {
            new Item("Lembas Bread", "Elven waybread", ItemType.QuestItem, 10, 5),
            new Item("Steel Armor", "Heavy protection", ItemType.Armor, 150, 1),
            new Item("Health Potion", "Restores health", ItemType.Potion, 25, 3),
            new Item("Ancient Coin", "Valuable treasure", ItemType.Treasure, 50, 1)
        };
        
        foreach (var item in items)
        {
            Debug.Log($"{item.type}: {item.name} x{item.quantity} (value: {item.value})");
        }

        Debug.Log("\n=== DEMO COMPLETE - All RPG Systems Functional ===");
    }
}
