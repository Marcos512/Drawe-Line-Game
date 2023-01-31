using System;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveLavelData
{
    public LevelProgress[] levelsProgress;

    private const string saveKey = "LevelProgressSave";

    public void TryLoad()
    {
        Load();
        if (levelsProgress == null)
        {
            int count = SceneManager.sceneCountInBuildSettings;
            levelsProgress = new LevelProgress[count];
            Save();
        }
    }

    public void SaveLevelProgress(int CollectStars)
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (!levelsProgress[index].LevelCompleted
            || levelsProgress[index].CollectStars < CollectStars)
        {
            levelsProgress[index] = new LevelProgress(true, CollectStars);
        }
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveLavelData>(saveKey);
        levelsProgress = data.levelsProgress;
    }

    private void Save()
    {
        SaveManager.Save(saveKey, this);
    }
}

