using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private SaveLavelData _saveLevelData = new SaveLavelData();

    public bool MuteSound = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _saveLevelData.TryLoad();
        }
    }

    public void Save(int collectStars) =>
        _saveLevelData.SaveLevelProgress(collectStars);


    public LevelProgress[] GetLevelProgress() =>
        _saveLevelData.levelsProgress;
}
