using System.Collections.Generic;
using UnityEngine;

public class CitizenInfoPrinter : MonoBehaviour
{
    public PopulationManager populationManager; // Assign this in the Unity Inspector

    void Start()
    {
        if (populationManager == null)
        {
            Debug.LogError("PopulationManager is not assigned to CitizenInfoPrinter.");
            return;
        }

        PrintCitizenInfo();
    }

    void PrintCitizenInfo()
    {
        List<Person> citizensList = populationManager.citizensList;

        if (citizensList.Count == 0)
        {
            Debug.Log("No citizens available.");
            return;
        }

        foreach (Person citizen in citizensList)
        {
            Debug.Log($"## {citizen.name} ##");
            Debug.Log($"Age: {citizen.age}");
            Debug.Log($"Happiness %: {citizen.happinessPercentage}");
            Debug.Log($"Bank Account: {citizen.bankAccount} euros");
        }
    }
}
