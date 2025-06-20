using UnityEngine;
using System;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance { get; private set; }

    public int Money { get; private set; } = 100;
    public float Influence { get; private set; } = 0f;
    public float Reputation { get; private set; } = 0f;
    public float Relationship { get; private set; } = 0f;
    public float Suspicion { get; private set; } = 0f;

    public event Action OnStatsChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeStats(int moneyDelta, float influenceDelta, float reputationDelta, float relationshipDelta, float suspicionDelta)
    {
        Money += moneyDelta;
        Influence = Mathf.Clamp01(Influence + influenceDelta);
        Reputation = Mathf.Clamp01(Reputation + reputationDelta);
        Relationship = Mathf.Clamp01(Relationship + relationshipDelta);
        Suspicion = Mathf.Clamp01(Suspicion + suspicionDelta);

        OnStatsChanged?.Invoke();

        Debug.Log($"[StatsManager] Stats updated: $$$ {Money}, Influence {Influence}, Reputation {Reputation}, Relationship {Relationship}, Suspicion {Suspicion}");
    }
}
