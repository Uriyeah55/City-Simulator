using UnityEngine;
using UnityEngine.UI;

public class HappinessUI : MonoBehaviour
{
    public Image happinessFill;      // Green (Happy)
    public Image happinessBackground; // Red (Unhappy)

    public void UpdateHappiness(float happinessPercentage)
    {
        float normalized = happinessPercentage / 100f;
        happinessFill.fillAmount = normalized;

        // Optional: Change colors dynamically
        if (happinessPercentage > 50)
        {
            happinessFill.color = Color.green;
        }
        else
        {
            happinessFill.color = new Color(1f, 0.5f, 0f); // Orange tone
        }
    }
}
