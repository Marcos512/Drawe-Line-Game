using System;

[Serializable]
public class LevelProgress
{
    public bool LevelCompleted;

    public int CollectItems;

    public LevelProgress(bool levelCompleted = false, int collectItems = 0)
    {
        LevelCompleted = levelCompleted;
        CollectItems = collectItems;
    }
}