using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCitizensBy : MonoBehaviour
{
    public PopulationManager populationManager;
    public City city; // Reference to City to recreate buttons
    private bool sortByAgeDescending = true; // Flag to toggle sorting order

    public void SortCitizensByName()
    {
        if (populationManager == null || city == null)
        {
            Debug.LogError("PopulationManager or City is not assigned!");
            return;
        }

        if (populationManager.citizensList.Count == 0)
        {
            Debug.LogWarning("No citizens to sort!");
            return;
        }

        // Sort alphabetically
        populationManager.citizensList.Sort((a, b) => a.name.CompareTo(b.name));

        // Update the UI
        city.CreateCitizenButtons(populationManager.citizensList);
    }

public void SortCitizensByAge()
    {
        if (populationManager == null || city == null)
        {
            Debug.LogError("PopulationManager or City is not assigned!");
            return;
        }

        if (populationManager.citizensList.Count == 0)
        {
            Debug.LogWarning("No citizens to sort!");
            return;
        }

        // Toggle sorting order based on the flag
        if (sortByAgeDescending)
        {
            // Sort by age in descending order
            populationManager.citizensList.Sort((a, b) => b.age.CompareTo(a.age));
        }
        else
        {
            // Sort by age in ascending order
            populationManager.citizensList.Sort((a, b) => a.age.CompareTo(b.age));
        }

        // Toggle the sorting order flag for the next click
        sortByAgeDescending = !sortByAgeDescending;

        // Update the UI with sorted citizens
        city.CreateCitizenButtons(populationManager.citizensList);
    }
}
