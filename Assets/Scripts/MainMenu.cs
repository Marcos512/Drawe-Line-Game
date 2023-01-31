using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelProgress[] levels;

    [SerializeField]
    private RectTransform _buttonsGrid;

    [SerializeField]
    private GameObject _buttonPrefab;

    List<GameObject> buttons = new List<GameObject>();

    public void Play()
    {
        if (GameManager.Instance)
        {
            levels = GameManager.Instance.GetLevelProgress();
        }

        if (buttons.Count > 0)
            ClearButtons();

        int i = 0;
        bool lastComplit = true;
        foreach(var level in levels.Skip(1))
        {
            var button = Instantiate(_buttonPrefab);
            button.transform.SetParent(_buttonsGrid.transform);
            button.transform.localScale = Vector3.one;
            button.name += ++i;
            var but = button.GetComponent<Button>();
            but.interactable = lastComplit;
            int num = i;
            but.onClick.AddListener(() => LoadLevel(num));
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = i.ToString();
            var StarImages = button.GetComponentsInChildren<Image>();
            StarColor(level.CollectStars,StarImages);
            buttons.Add(button);
            lastComplit = level.LevelCompleted; 
        }
    }

    private void StarColor(int activStars, Image[] stars)
    {
        int i = activStars;
        for (; i>0; i--)
        {
            stars[i].color = Color.white;
        }
    }

    private void ClearButtons()
    {
        foreach(var button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }

    public void LoadLevel(int level)
    {
            SceneManager.LoadScene(level);
    }
}