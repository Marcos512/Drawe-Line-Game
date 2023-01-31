using System;

[Serializable]
public class LevelProgress
{
    public bool LevelCompleted;

    public int CollectStars;

    public LevelProgress(bool levelCompleted = false, int collectStars = 0)
    {
        LevelCompleted = levelCompleted;
        CollectStars = collectStars;
    }
}