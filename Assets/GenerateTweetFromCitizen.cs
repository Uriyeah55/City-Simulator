using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateTweetFromCitizen : MonoBehaviour
{
    public TextMeshProUGUI tweetDisplay;  // The UI Text element where the tweet will appear
    public PopulationManager populationManager;  // Reference to the PopulationManager
    public Button tweetButton;  // Reference to the button that will trigger tweet generation

    void Start()
    {
        // Ensure the button triggers the correct function (no self-calling)
        tweetButton.onClick.AddListener(GenerateTweet);
        tweetButton.interactable = false;  // Initially disable the button until citizens are generated
    }

    // This function is called after citizens are generated
    public void EnableTweetButton()
    {
        // Enable the tweet button after the citizens are generated
        tweetButton.interactable = true;
    }

    public void GenerateTweet()
    {
        // Ensure citizens have been generated before attempting to create a tweet
        if (populationManager.citizensList.Count == 0)
        {
            tweetDisplay.text = "Please generate citizens first!";
            Debug.LogWarning("No citizens generated yet!");
            return;  // Exit the function if no citizens are available
        }

        // Get a random citizen who is 18 or older
        Person citizen = GetRandomCitizen18OrOlder();
        
        if (citizen != null)
        {
            // Generate the tweet
            string tweet = $"{citizen.name}, Age: {citizen.age} - #JustVoted #LivingLife";
            
            // Display the tweet
            tweetDisplay.text = tweet;
            Debug.Log("Tweet generated: " + tweet);
        }
        else
        {
            tweetDisplay.text = "No citizens eligible to tweet!";
            Debug.LogWarning("No citizens 18 or older to generate a tweet.");
        }
    }

    // Helper method to find a random citizen who is 18 or older
    private Person GetRandomCitizen18OrOlder()
    {
        // Filter the list to get only citizens 18 or older
        var eligibleCitizens = populationManager.citizensList.FindAll(citizen => citizen.age >= 18);
        
        if (eligibleCitizens.Count > 0)
        {
            // Randomly select a citizen from the eligible list
            int randomIndex = Random.Range(0, eligibleCitizens.Count);
            return eligibleCitizens[randomIndex];
        }
        
        return null; // No eligible citizens found
    }
}
