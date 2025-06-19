using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChoiceButtonRandom : MonoBehaviour // для тестировки
{
    [SerializeField] private Vector2Int moneyRange = new Vector2Int(-50, 50);
    [SerializeField] private Vector2 influenceRange = new Vector2(-0.2f, 0.2f);
    [SerializeField] private Vector2 reputationRange = new Vector2(-0.2f, 0.2f);
    [SerializeField] private Vector2 relationshipRange = new Vector2(-0.2f, 0.2f);
    [SerializeField] private Vector2 suspicionRange = new Vector2(-0.2f, 0.2f);

    [SerializeField] private CutsceneManager cutsceneManager;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnChoiceSelected);
    }

    private void OnChoiceSelected()
    {
        int moneyDelta = Random.Range(moneyRange.x, moneyRange.y + 1);
        float influenceDelta = Random.Range(influenceRange.x, influenceRange.y);
        float reputationDelta = Random.Range(reputationRange.x, reputationRange.y);
        float relationshipDelta = Random.Range(relationshipRange.x, relationshipRange.y);
        float suspicionDelta = Random.Range(suspicionRange.x, suspicionRange.y);

        StatsManager.Instance.ChangeStats(moneyDelta, influenceDelta, reputationDelta, relationshipDelta, suspicionDelta);

        cutsceneManager.CloseCutscene();
    }
}
