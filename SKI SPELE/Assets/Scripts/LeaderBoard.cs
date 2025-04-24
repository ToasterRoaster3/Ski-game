using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();
    [SerializeField] private TMPro.TextMeshProUGUI[] timeTexts;

    private void Awake()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            float savedTime = PlayerPrefs.GetFloat("time" + i, -1f);
            if (savedTime >= 0f)
            {
                bestTimes.Add(savedTime);
            }
        }

        // Fill remaining spots with 0s
        while (bestTimes.Count < 5)
        {
            bestTimes.Add(0f);
        }

        DisplayTimes();
    }
    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
    }

    private void SaveData()
    {
        bestTimes.Sort();
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
            {
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
            }
        }
        PlayerPrefs.Save();
    }
    
    public void DisplayTimes()
    {
        for (int i = 0; i < timeTexts.Length; i++)
        {
            float time = bestTimes[i];
            timeTexts[i].text = (i + 1) + ". " + 
                                (time > 0 ? time.ToString("F2") + "s" : "--");
        }
    }

}
