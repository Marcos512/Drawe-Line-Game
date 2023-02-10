using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public static event Action WinAction;
    public static event Action LoseAction;

    [SerializeField]
    private GameStatus _gameStatus;

    [SerializeField]
    private DrawLine _drawLine;

    [SerializeField]
    private List<Rigidbody2D> _rigidbodies;

    private Status _lastStatus;

    private void Awake()
    {
        ToggleSimulate(false);
    }

    private void Update()
    {
        Status status;
        switch (status = _gameStatus.UpdateStatus())
        {
            case Status.Win: if (_lastStatus != Status.Win) WinMethod(); break;
            case Status.Lose: if (_lastStatus != Status.Lose) LoseMethod(); break;
            case Status.Play: if (_lastStatus != Status.Play) StartSimulation(); break;
            case Status.Prepare: Draw(); break;
        }
        _lastStatus = status;
    }

    private void Draw()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            if (Input.GetMouseButtonDown(0))
            {
                _drawLine.TryStartDrawLine();
            }

        if (Input.GetMouseButton(0) && _drawLine.LineStartDraw)
        {
            _drawLine.TryAddNextPoint();
        }

        if (Input.GetMouseButtonUp(0) && _drawLine.LineStartDraw)
        {
            _drawLine.FinishingDrawLine();
        }
    }
    private void LoseMethod()
    {
        ToggleSimulate(false);
        LoseAction?.Invoke();
    }

    private void WinMethod()
    {
        ToggleSimulate(false);
        WinAction?.Invoke();

        SaveProgress();
    }

    private void SaveProgress()
    {
        if (GameManager.Instance)
        {
            int items = ItemCollecter.ItemsCount;
            GameManager.Instance.Save(items);
        }
    }

    private void StartSimulation()
    {
        ToggleSimulate(true);
    }

    private void ToggleSimulate(bool toggle)
    {
        foreach (var ob in _rigidbodies)
        {
            ob.bodyType = toggle ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
        }
    }
}

