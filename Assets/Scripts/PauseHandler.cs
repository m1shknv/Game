using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PauseHandler : MonoBehaviour
{
    private PlayerInput _input;
    private IPopup _pausePopup;

    private bool _isPaused;

    public event Action<bool> OnPauseChanged;

    private void Awake()
    {
        TryGetComponent(out _input);
        if (_input)
        {
            _input.OnPausePressed += HandlePausePressed;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        if (_input)
        {
            _input.OnPausePressed -= HandlePausePressed;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        FindPausePopup();

        _isPaused = false;
        Time.timeScale = 1f;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPausePopup();

        _isPaused = false;
        Time.timeScale = 1f;
    }

    private void FindPausePopup()
    {
        _pausePopup = FindObjectsOfType<Popup>().FirstOrDefault(p => p.gameObject.name.Contains("PausePopup")) as IPopup;
    }

    private void HandlePausePressed()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        SetPause(!_isPaused);
    }

    public void SetPause(bool pause)
    {
        if (_pausePopup == null) 
            return;

        if (_isPaused == pause) 
            return;

        _isPaused = pause;

        Time.timeScale = _isPaused ? 0f : 1f;

        if (_isPaused)
            _pausePopup.Show();
        else
            _pausePopup.Hide();

        OnPauseChanged?.Invoke(_isPaused);
    }

    public bool IsPaused => _isPaused;
}
