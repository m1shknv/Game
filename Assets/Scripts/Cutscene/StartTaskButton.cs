using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartTaskButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TimedRewardTask _rewardTask;

    private Button _button;

    private void Awake()
    {
        TryGetComponent(out _button);
        _button.onClick.AddListener(OnStartTask);
    }

    private void OnEnable()
    {
        if (_rewardTask)
            _rewardTask.OnTaskCompleted += OnTaskCompleted;

        UpdateButtonInteractable();
    }

    private void OnDisable()
    {
        if (_rewardTask)
            _rewardTask.OnTaskCompleted -= OnTaskCompleted;
    }

    private void OnStartTask()
    {
        if (_rewardTask && !_rewardTask.IsRunning)
        {
            _rewardTask.StartTask();
            UpdateButtonInteractable();
        }
    }

    private void OnTaskCompleted()
    {
        UpdateButtonInteractable();
    }

    private void UpdateButtonInteractable()
    {
        if (_rewardTask)
        {
            _button.interactable = !_rewardTask.IsRunning;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
