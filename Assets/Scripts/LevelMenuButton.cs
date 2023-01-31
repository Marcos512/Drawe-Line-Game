using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenuButton : ScriptableObject
{
    public int Level;

    public int Stars;

    public bool LevelOpen;

    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _starsText;

    public void LoadLevel()
    {
        SceneManager.LoadScene(Level);
    }
}