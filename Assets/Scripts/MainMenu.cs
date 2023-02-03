using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelProgress[] levels;

    [SerializeField]
    private RectTransform _buttonsGrid;

    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private Toggle _soundToggle;

    private List<GameObject> _buttons = new List<GameObject>();

    private void Awake()
    {
        if (GameManager.Instance)
        {
            _soundToggle.isOn = GameManager.Instance.MuteSound;
        }
    }

    public void Play()
    {
        if (GameManager.Instance)
        {
            levels = GameManager.Instance.GetLevelProgress();
        }

        if (_buttons.Count > 0)
            ClearButtons();

        int i = 1;
        bool lastComplit = true;
        foreach (var level in levels.Skip(1))
        {
            InitNewButton(i++, lastComplit, level);
            lastComplit = level.LevelCompleted;
        }
    }

    private void InitNewButton(int i, bool interactable, LevelProgress level)
    {
        var levelButton = Instantiate(_buttonPrefab);
        levelButton.transform.SetParent(_buttonsGrid.transform);
        levelButton.transform.localScale = Vector3.one;
        levelButton.name += i;

        var button = levelButton.GetComponent<Button>();
        button.interactable = interactable;
        button.onClick.AddListener(() => LoadLevel(i));

        var text = levelButton.GetComponentInChildren<TextMeshProUGUI>();
        text.text = i.ToString();

        var ItemImages = levelButton.GetComponentsInChildren<Image>();
        ChangeItemColor(level.CollectItems, ItemImages);

        _buttons.Add(levelButton);
    }

    private void ChangeItemColor(int collectItems, Image[] item)
    {
        for (int i = collectItems; i > 0; i--)
        {
            item[i].color = Color.white;
        }
    }

    private void ClearButtons()
    {
        foreach (var button in _buttons)
        {
            Destroy(button);
        }
        _buttons.Clear();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void SoundSwithcer(bool swither)
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.MuteSound = swither;
        }
    }
}