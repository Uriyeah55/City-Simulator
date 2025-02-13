using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCitizensBy : MonoBehaviour
{
    public PopulationManager populationManager;
    public City city; // Reference to City to recreate buttons

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
}
