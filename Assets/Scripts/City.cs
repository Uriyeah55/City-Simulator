using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : MonoBehaviour
{
    public PopulationManager populationManager;
    public Transform citizenListParent; // UI panel for citizen buttons
    public GameObject citizenButtonPrefab; // Button template prefab
    public TMP_Text citizenInfoText; // UI text to display citizen info

    private List<GameObject> citizenButtons = new List<GameObject>();

  void Start()
{
    /*
    if (populationManager != null && populationManager.citizensList.Count > 0)
    {
        CreateCitizenButtons();
    }
    else
    {
        Debug.LogWarning("Population not yet generated.");
    }
    */
}


    public void CreateCitizenButtons()
    {
        Debug.Log("Total citizens: " + populationManager.citizensList.Count);

        // Clear old buttons
        foreach (var button in citizenButtons)
        {
            Destroy(button);
        }
        citizenButtons.Clear();

        foreach (Person citizen in populationManager.citizensList)
        {
            GameObject buttonObj = Instantiate(citizenButtonPrefab, citizenListParent);
            TMP_Text buttonText = buttonObj.GetComponentInChildren<TMP_Text>();
            buttonText.text = citizen.name; // Display the name on button

            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => ShowCitizenInfo(citizen));

            citizenButtons.Add(buttonObj);
        }
    }

    public void ShowCitizenInfo(Person citizen)
    {
        citizenInfoText.text = $"Name: {citizen.name}\n" +
                               $"Age: {citizen.age}\n" +
                               $"Happiness: {citizen.happinessPercentage}%\n" +
                               $"Bank Account: ${citizen.bankAccount}";
    }
}
