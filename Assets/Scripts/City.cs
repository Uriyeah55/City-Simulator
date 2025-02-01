using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : MonoBehaviour
{
    public TMP_Text NotifText;
    public Button generateButton; 
    public PopulationManager populationManager;
    public List<Person> citizensList { get; private set; }

    
    public List<string> happinessNotif = new List<string>();

    void Start()
    {
        if (generateButton != null)
        {
            generateButton.onClick.AddListener(() => GeneratePopulation(10));
        }
    }

    public void GeneratePopulation(int count)
    {
        populationManager.GeneratePopulation(count);
        UpdateNotifications();
    }

    void UpdateNotifications()
    {
        happinessNotif.Clear();
        NotifText.text = "";

        foreach (Person citizen in populationManager.citizensList)
        {
            if (citizen.hasGoodDay())
            {
                happinessNotif.Add("Citizen " + citizen.name + " has had a good day!");
            }
            happinessNotif.Add("Citizen " + citizen.name + " current happiness % is " + citizen.happinessPercentage);
        }

        foreach (string notification in happinessNotif)
        {
            NotifText.text += "\n" + notification;
        }

        Debug.Log("Average Happiness: " + populationManager.CalculateAverageHappiness());
    }
}
