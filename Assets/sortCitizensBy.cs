using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortCitizensBy : MonoBehaviour
{
    public PopulationManager populationManager;
    public City city; // Reference to City to recreate buttons

    public void SortCitizensByName()
    {
        if (populationManager == null || city == null) return;

        // Create a sorted copy of the list (does NOT modify original list)
        List<Person> sortedCitizens = new List<Person>(populationManager.citizensList);
        sortedCitizens.Sort((a, b) => a.name.CompareTo(b.name));

        // Re-create buttons based on sorted list
        city.CreateCitizenButtons(sortedCitizens);
    }
}
