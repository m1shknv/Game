using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIController : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    [SerializeField] private Image _influenceFillImage;
    [SerializeField] private Image _reputationFillImage;
    [SerializeField] private Image _relationshipFillImage;
    [SerializeField] private Image _suspicionFillImage;

    private void Start()
    {
        StartCoroutine(WaitForStatsManager());
    }

    private IEnumerator WaitForStatsManager()
    {
        while (StatsManager.Instance == null)
        {
            yield return null;
        }

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
        _moneyText.text = StatsManager.Instance.Money.ToString();

        _influenceFillImage.fillAmount = StatsManager.Instance.Influence;
        _reputationFillImage.fillAmount = StatsManager.Instance.Reputation;
        _relationshipFillImage.fillAmount = StatsManager.Instance.Relationship;
        _suspicionFillImage.fillAmount = StatsManager.Instance.Suspicion;
    }
}
