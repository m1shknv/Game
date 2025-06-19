using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChoiceButton : MonoBehaviour
{
    [Header("Effects on Stats")]
    [SerializeField] private int moneyDelta = 0;
    [SerializeField] private float influenceDelta = 0f;
    [SerializeField] private float reputationDelta = 0f;
    [SerializeField] private float relationshipDelta = 0f;
    [SerializeField] private float suspicionDelta = 0f;

    [Header("References")]
    [SerializeField] private CutsceneManager cutsceneManager;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnChoiceSelected);
    }

    private void OnChoiceSelected()
    {
        StatsManager.Instance.ChangeStats(moneyDelta, influenceDelta, reputationDelta, relationshipDelta, suspicionDelta);

        cutsceneManager.CloseCutscene();
    }
}
