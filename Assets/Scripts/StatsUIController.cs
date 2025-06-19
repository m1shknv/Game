using UnityEngine;
using UnityEngine.UI;

public class StatsUIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Text moneyText;
    [SerializeField] private Image influenceFillImage;
    [SerializeField] private Image reputationFillImage;
    [SerializeField] private Image relationshipFillImage;
    [SerializeField] private Image suspicionFillImage;

    private void OnEnable()
    {
        StatsManager.Instance.OnStatsChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        if (StatsManager.Instance)
            StatsManager.Instance.OnStatsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        moneyText.text = StatsManager.Instance.Money.ToString();
        influenceFillImage.fillAmount = StatsManager.Instance.Influence;
        reputationFillImage.fillAmount = StatsManager.Instance.Reputation;
        relationshipFillImage.fillAmount = StatsManager.Instance.Relationship;
        suspicionFillImage.fillAmount = StatsManager.Instance.Suspicion;
    }
}
