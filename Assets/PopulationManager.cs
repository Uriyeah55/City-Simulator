using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopulationManager : MonoBehaviour
{
    public List<Person> citizensList { get; private set; }
    private PersonCreator creator;
     public TMP_InputField inputField; 
     public GameObject manager;

     public Button generateBtn;

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
    int citizenCount = ValidateCitizenInput(inputField.text);

    if (citizenCount > 0)
    {
        hideInputAndButton();
        GeneratePopulation(citizenCount);

              // Ensure City updates the UI list
        FindObjectOfType<City>().CreateCitizenButtons();
        float actualHappinessAverage=manager.GetComponent<HappinessCalculator>().CalculateAverageHappiness(citizensList);

        manager.GetComponent<HappinessUI>().UpdateHappiness(actualHappinessAverage);
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

 
    public void hideInputAndButton()
    {
        generateBtn.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
    }
}
