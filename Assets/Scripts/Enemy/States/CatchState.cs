using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchState : State
{
    [SerializeField] private GameController _gameController;

    private void OnEnable()
    {
        _gameController.ReloadGame();
    }
}
