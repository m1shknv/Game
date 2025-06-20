using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private EffectData effect;
    [SerializeField] private CutsceneManager cutsceneManager;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnChoiceSelected);
    }

    private void OnChoiceSelected()
    {
        StatsManager.Instance.ChangeStats(
            effect.moneyDelta,
            effect.influenceDelta,
            effect.reputationDelta,
            effect.relationshipDelta,
            effect.suspicionDelta
        );

        cutsceneManager.CloseCutscene();
    }
}
