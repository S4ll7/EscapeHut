using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeZone : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameController _gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (_player.IsAllowedToEscape)
        {
            _gameController.Win();
        }
        else
        {
            Debug.Log("save kid");
        }
    }
}
