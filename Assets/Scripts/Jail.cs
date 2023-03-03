using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jail : MonoBehaviour
{
    [SerializeField] private CanvasGroup _freeMenu;
    [SerializeField] private FreeButton _freeButton;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Player _player;
    [SerializeField] private Kid _prisoner;
    [SerializeField] private float _timeToEscape;

    private float _escapeValue = 0;
    private Coroutine _rescue;
    private bool _isJailFull = true;

    public bool IsJailFull => _isJailFull;

    private void OnEnable()
    {
        _freeButton.FreeStarted += StartFreeing;
        _freeButton.FreeEnded += StopFreeing;
    }

    private void OnDisable()
    {
        _freeButton.FreeStarted -= StartFreeing;
        _freeButton.FreeEnded -= StopFreeing;
    }

    private IEnumerator Rescue()
    {
        _player.StartRescue();
        _progressBar.value = 0;
        while (_escapeValue < _timeToEscape)
        {
            _escapeValue += Time.deltaTime;
            _progressBar.value = _escapeValue / _timeToEscape;
            yield return null;
        }
        _progressBar.value = 1;
        _isJailFull = false;
        CloseRescueMenu();
        _prisoner.Escape();
        _player.StopRescue();
        _player.AddKid(_prisoner);
    }

    private void StartFreeing()
    {
        _rescue = StartCoroutine(Rescue());
    }

    private void StopFreeing()
    {
        if (_rescue != null)
        {
            _player.StopRescue();
            _escapeValue = 0;
            _progressBar.value = 0;
            StopCoroutine(_rescue);
        }
    }

    private void OpenRescueMenu()
    {
        _progressBar.value = 0;
        _freeMenu.gameObject.SetActive(true);
    }

    private void CloseRescueMenu()
    {
        _freeMenu.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Kid>(out Kid kid) && _isJailFull)
        {
            if (!kid.IsJailed)
            {
                OpenRescueMenu();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (_isJailFull)
        {
            CloseRescueMenu();
        }
    }
}
