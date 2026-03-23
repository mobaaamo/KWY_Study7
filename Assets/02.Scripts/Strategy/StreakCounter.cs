using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public struct AbilityThreshold
{
    public Ability ability;
    public int minimumStreak;
}
public class StreakCounter : MonoBehaviour
{

    [SerializeField] private List<AbilityThreshold> m_AbilityThresholds;
    [SerializeField] private AbilityRunner m_AbilityRunner;


    [SerializeField] private TextMeshProUGUI m_StreakText;

    private int m_CurrentStreak = 0;


    public int CurrentStreak
    {
        get =>m_CurrentStreak;
        set
        {
            m_CurrentStreak = value;

            UpdateCurrentAbility();
            UpdateStreakText();
        }
    }
    void Start()
    {
        UpdateCurrentAbility();
        UpdateStreakText();
    }
    private void OnEnable()
    {
        GameEvents.OnCollectibleCollected += IncreamentStreak;
    }
    private void OnDisable()
    {
        GameEvents.OnCollectibleCollected -= IncreamentStreak;
    }

    private void UpdateStreakText()
    {
        if(m_StreakText != null)
        {
            m_StreakText.text =  m_CurrentStreak.ToString();
        }
    }
    private void UpdateCurrentAbility()
    {
        if (m_AbilityRunner == null || m_AbilityThresholds == null || m_AbilityThresholds.Count == 0)
        {
            return;
        }

        Ability bestAbility = null;
        int bestMin = int.MinValue;

        for(int i = 0;i<m_AbilityThresholds.Count;i++)
        {
            var th = m_AbilityThresholds[i];

            if (th.ability == null) continue;

            //현재 Streak=7
            //3->Fireball, 5->아이스 볼 10->광역스킬
            if(th.minimumStreak <=m_CurrentStreak && th.minimumStreak>bestMin)
            {
                bestMin = th.minimumStreak;
                bestAbility = th.ability;
            }

            if(bestAbility!=null)
            {
                m_AbilityRunner.CurrentAbility = bestAbility;
            }
        }
    }
    public void IncreamentStreak()
    {
        CurrentStreak++;
    }
}
