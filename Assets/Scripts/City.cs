using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class City : MonoBehaviour
{
    public Transform buttonContainer; // Parent object for buttons
    public GameObject citizenButtonPrefab; // Prefab for citizen buttons
    public TMP_Text displayInfoText;
    public Button closeInfoBtn;


public void CreateCitizenButtons(List<Person> sortedCitizens = null)
{
    if (buttonContainer == null)
    {
        Debug.LogError("ButtonContainer is not assigned in City!");
        return;
    }

    if (citizenButtonPrefab == null)
    {
        Debug.LogError("CitizenButtonPrefab is not assigned in City!");
        return;
    }

    List<Person> citizensToShow = sortedCitizens ?? FindObjectOfType<PopulationManager>().citizensList;

    foreach (Transform child in buttonContainer)
    {
        Destroy(child.gameObject);
    }

    Debug.Log($"Creating {citizensToShow.Count} citizen buttons.");

    foreach (Person citizen in citizensToShow)
    {
        GameObject newButton = Instantiate(citizenButtonPrefab, buttonContainer);
        
        // Set the name text
        TMP_Text textComponent = newButton.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = citizen.name;
        }
        else
        {
            Debug.LogError("TMP_Text component is missing on the button prefab!");
        }

        // Find the button for displaying info (assuming it's a child of the prefab)
        Button infoButton = newButton.transform.Find("InfoButton")?.GetComponent<Button>(); // "InfoButton" should be the name of the button inside the prefab
        if (infoButton != null)
        {
            infoButton.onClick.AddListener(() => ShowCitizenInfo(citizen));
        }
        else
        {
            Debug.LogError("InfoButton is missing in the button prefab!");
        }
    }
}



        void ShowCitizenInfo(Person citizen)
    {
        displayInfoText.gameObject.SetActive(true);
        if (displayInfoText != null)
        {
            closeInfoBtn.gameObject.SetActive(true);
            displayInfoText.text = $"Name: {citizen.name}\n" +
                                   $"Age: {citizen.age}\n" +
                                   $"Happiness: {citizen.happinessPercentage}%";
        }
        else
        {
            Debug.LogError("displayInfoText is not assigned!");
        }
    }
}
