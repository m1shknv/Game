using UnityEngine;
using UnityEngine.UI;

public class LocationTimerUI : MonoBehaviour
{
    [SerializeField] private LocationTimer timer;
    [SerializeField] private Text timerText;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color alertColor = Color.red;

    private bool _alerted;

    private void Update()
    {
        if (timer == null || timerText == null) return;

        float remaining = timer.GetRemainingTime();
        int minutes = Mathf.FloorToInt(remaining / 60f);
        int seconds = Mathf.FloorToInt(remaining % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";

        if (!_alerted && remaining <= 0f)
        {
            timerText.color = alertColor;
            _alerted = true;
        }
        else if (!_alerted)
        {
            timerText.color = normalColor;
        }
    }
}
