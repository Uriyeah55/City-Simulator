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
        // If no sorted list is provided, use the default one
        List<Person> citizensToShow = sortedCitizens ?? FindObjectOfType<PopulationManager>().citizensList;

        // Remove existing buttons before creating new ones
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // Create new buttons based on sorted list
        foreach (Person citizen in citizensToShow)
        {
            GameObject newButton = Instantiate(citizenButtonPrefab, buttonContainer);
            newButton.GetComponentInChildren<TMPro.TMP_Text>().text = citizen.name;
            newButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowCitizenInfo(citizen));
        }
    }

    void ShowCitizenInfo(Person citizen)
    {
        Debug.Log($"Citizen: {citizen.name}, Age: {citizen.age}, Happiness: {citizen.happinessPercentage}%");
    }
}
