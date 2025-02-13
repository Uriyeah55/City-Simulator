using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class City : MonoBehaviour
{
    public Transform buttonContainer; // Parent object for buttons
    public GameObject citizenButtonPrefab; // Prefab for citizen buttons

    
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

    // If no sorted list is provided, use the default one
    List<Person> citizensToShow = sortedCitizens ?? FindObjectOfType<PopulationManager>().citizensList;

    // Remove existing buttons before creating new ones
    foreach (Transform child in buttonContainer)
    {
        Destroy(child.gameObject);
    }

Debug.Log($"Creating {citizensToShow.Count} citizen buttons.");

    // Create new buttons based on sorted list
    foreach (Person citizen in citizensToShow)
    {
        GameObject newButton = Instantiate(citizenButtonPrefab, buttonContainer);
        TMP_Text textComponent = newButton.GetComponentInChildren<TMP_Text>();

        if (textComponent != null)
        {
            textComponent.text = citizen.name;
        }
        else
        {
            Debug.LogError("TMP_Text component is missing on the button prefab!");
        }

        Button buttonComponent = newButton.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(() => ShowCitizenInfo(citizen));
        }
        else
        {
            Debug.LogError("Button component is missing on the button prefab!");
        }
    }
}


    void ShowCitizenInfo(Person citizen)
    {
        Debug.Log($"Citizen: {citizen.name}, Age: {citizen.age}, Happiness: {citizen.happinessPercentage}%");
    }
}
