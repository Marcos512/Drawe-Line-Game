using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    private FinishTrigger[] _finishTriggers;

    private bool _gameStart = false;
    public static bool OnLoseTrigger = false;

    private void Awake()
    {
        OnLoseTrigger = false;
    }

    public Status UpdateStatus()
    {
        if (!_gameStart)
            return Status.Prepare;
        else
        {
            if (ChekFinishTriggers())
                return Status.Win;

            if (OnLoseTrigger)
            {
                return Status.Lose;
            }
            
            return Status.Play;
        }
    }

    public void StartGame()
    {
        _gameStart = true;
    }

    private bool ChekFinishTriggers()
    {
        if (_finishTriggers.Length == 0)
        {
            Debug.Log("Добавте финиш");
            return false;
        }

        foreach (var finish in _finishTriggers)
        {
            if (!finish.AimFinished) return false;
        }

        return true;
    }
}
