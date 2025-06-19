using System.Linq;
using UnityEngine;

public class LocationTimer : MonoBehaviour
{
    [SerializeField] private float durationInSeconds = 60f;

    private IPopup _endDayPopup;

    private float _timeRemaining;
    private bool _isRunning;

    public bool IsRunning => _isRunning;

    private void Awake()
    {
        _timeRemaining = durationInSeconds;
        _isRunning = false;

        _endDayPopup = FindObjectsOfType<Popup>().FirstOrDefault(p => p.gameObject.name.Contains("EndDayPopup")) as IPopup;
    }

    private void Update()
    {
        if (!_isRunning || _timeRemaining <= 0f) 
            return;

        _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <= 0f)
        {
            _timeRemaining = 0f;
            _isRunning = false;
            OnTimerEnd();
        }
    }

    public void StartTimer()
    {
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    private void OnTimerEnd()
    {
        Debug.Log("Рабочий день окончен.");
        _endDayPopup.Show();
    }

    public float GetRemainingTime() => _timeRemaining;
}
