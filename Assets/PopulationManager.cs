using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PopulationManager : MonoBehaviour
{
    public List<Person> citizensList { get; private set; }
    private PersonCreator creator;
     public TMP_InputField inputField; 

    void Awake()
    {
        creator = GetComponent<PersonCreator>();
        citizensList = new List<Person>();
    }

    public void GeneratePopulation(int count)
    {
        citizensList.Clear(); // Reset the population

        for (int i = 0; i < count; i++)
        {
            citizensList.Add(creator.GeneratePerson());
            
        }

        Debug.Log("Generated " + citizensList.Count + " citizens.");
    }

public void OnGenerateButtonClicked()
{
    Debug.Log("Button clicked!");
    int citizenCount = ValidateCitizenInput(inputField.text);
    Debug.Log("haurien de crearse " + citizenCount + " ciutadans");

    if (citizenCount > 0)
    {
        Debug.Log("Valid number: " + citizenCount);
        GeneratePopulation(citizenCount);
    }
    else
    {
        Debug.LogWarning("Invalid input.");
    }
}


        int ValidateCitizenInput(string input)
    {
        if (int.TryParse(input, out int value) && value > 0)
        {
            return value;
        }
        return -1; // Invalid input
    }

    public float CalculateAverageHappiness()
    {
        if (citizensList.Count == 0) return 0f;

        float totalHappiness = 0f;
        foreach (Person citizen in citizensList)
        {
            totalHappiness += citizen.happinessPercentage;
        }

        return totalHappiness / citizensList.Count;
    }
}
