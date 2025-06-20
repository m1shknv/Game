using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimedRewardTask : MonoBehaviour
{
    [SerializeField] private float _delaySeconds = 120f; 
    [SerializeField] private EffectData _rewardEffect;
    [SerializeField] private Text _timerText;

    private bool taskStarted = false;
    private float timeRemaining;

    public bool IsRunning => taskStarted && timeRemaining > 0f;

    public event Action OnTaskCompleted;

    public void StartTask()
    {
        if (!taskStarted)
        {
            taskStarted = true;
            timeRemaining = _delaySeconds;

            StartCoroutine(TaskCoroutine());
            Debug.Log($"Task started: after {_delaySeconds} seconds, reward will be applied.");
        }
    }

    private IEnumerator TaskCoroutine()
    {
        while (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
            yield return null;
        }

        ApplyReward();

        _timerText.text = "00:00";

        taskStarted = false;
        OnTaskCompleted?.Invoke();
    }

    private void ApplyReward()
    {
        StatsManager.Instance.ChangeStats(
            _rewardEffect.moneyDelta,
            _rewardEffect.influenceDelta,
            _rewardEffect.reputationDelta,
            _rewardEffect.relationshipDelta,
            _rewardEffect.suspicionDelta
        );

        Debug.Log($"Task completed: reward applied.");
    }

    private void UpdateTimerUI()
    {
        if (_timerText)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);

            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
