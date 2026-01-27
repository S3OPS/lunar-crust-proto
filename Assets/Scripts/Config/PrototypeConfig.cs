using System.IO;
using UnityEngine;

[System.Serializable]
public class PrototypeConfig
{
    public float extractorRate = 2.5f;
    public float conveyorRate = 2.0f;
    public float refineryRate = 1.25f;
    public float startOre = 0f;
    public float startIngots = 0f;
    public float moveSpeed = 5.5f;
    public float sprintMultiplier = 1.6f;
    public float mouseSensitivity = 1.8f;

    public static PrototypeConfig Load()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "config.json");
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<PrototypeConfig>(File.ReadAllText(path));
        }

        return new PrototypeConfig();
    }
}