using UnityEngine;

public class LevelSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _winSound;

    [SerializeField]
    private AudioSource _loseSound;

    private bool _mute = false;

    private void OnEnable()
    {
        if (GameManager.Instance)
        {
            _mute = GameManager.Instance.MuteSound;
        }
        MuteAudio(_mute);

        Game.WinAction += _winSound.Play;
        Game.LoseAction += _loseSound.Play;
    }

    private void OnDisable()
    {
        Game.WinAction -= _winSound.Play;
        Game.LoseAction -= _loseSound.Play;
    }

    private void MuteAudio(bool switcher)
    {
        if(switcher)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
}
