﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public static event Action WinAction;
    public static event Action LoseAction;

    [Header("Scripts")]
    [SerializeField]
    private GameStatus _gameStatus;

    [SerializeField]
    private DrawLine _drawLine;

    [Header("Ne scripts")]

    [SerializeField]
    private List<Rigidbody2D> _rigidbodies;

    [SerializeField]
    private AudioSource _winAudio;

    public static int StarsCollect; // переделать на ивенты

    private Status _lastStatus;

    private void Awake()
    {
        //var AllRigidbodies = FindObjectsOfType<Rigidbody2D>().ToList();
        //_rigidbodies.AddRange(AllRigidbodies);
        ToggleSimulate(false);
        StarsCollect = 0;
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
        _winAudio.Play();

        SaveProgress();
    }

    private void SaveProgress()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.Save(StarsCollect);
        }
    }

    public void StartSimulation()
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
