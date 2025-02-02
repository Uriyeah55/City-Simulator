using UnityEngine;
using UnityEngine.UI;

public class HappinessUI : MonoBehaviour
{
    public Image happinessCircle; // Assign the Image in Inspector

    public void UpdateHappiness(float happinessPercentage)
    {
        happinessCircle.fillAmount = happinessPercentage / 100f;
    }
}
