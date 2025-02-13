using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopulationManager : MonoBehaviour
{

    public City city; // Store reference to City

void Awake()
{
    creator = GetComponent<PersonCreator>();
    citizensList = new List<Person>();
    city = FindObjectOfType<City>(); // Cache reference

    if (city == null)
    {
        Debug.LogError("City script not found in the scene! Make sure it's assigned.");
    }
}



    public List<Person> citizensList { get; private set; }
    private PersonCreator creator;
     public TMP_InputField inputField; 
     public GameObject manager;

     public Button generateBtn;


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
    if (city != null)
{
    Debug.Log("Calling CreateCitizenButtons after generating citizens");
    city.CreateCitizenButtons();
}
else
{
    Debug.LogError("City reference is null in PopulationManager!");
}

    int citizenCount = ValidateCitizenInput(inputField.text);

    if (citizenCount > 0)
    {
        hideInputAndButton();
        GeneratePopulation(citizenCount);

    City city = FindObjectOfType<City>();
if (city != null)
{
    Debug.Log("Calling CreateCitizenButtons after generating citizens");
    city.CreateCitizenButtons();
}
else
{
    Debug.LogError("City script not found in the scene!");
}

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
        public void SortCitizensByName()
    {
        citizensList.Sort((a, b) => a.name.CompareTo(b.name)); // Sort alphabetically
        OnGenerateButtonClicked();
    }
}
