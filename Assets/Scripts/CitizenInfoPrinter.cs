using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CitizenInfoPrinter : MonoBehaviour
{
    public Button buttonPrefab; // Reference to the Button prefab
    private List<Person> citizensList; // List to hold citizens data
    public GameObject manager; // Reference to the manager GameObject
    public GameObject CitizensPanel; // Reference to the panel GameObject
    public GameObject DetailPanel; // Reference to the panel GameObject
        public TMP_Text infoText;
    


    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to populate citizens list after a delay
        StartCoroutine(PopulateCitizensListAfterDelay(1.0f));
    }

    IEnumerator PopulateCitizensListAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the function to populate the citizens list
        PopulateCitizensList();
    }

    void PopulateCitizensList()
    {
        // Fetch the list of citizens from the manager's City component
        citizensList = manager.GetComponent<City>().citizensList;

        // Check if citizensList is not null
        if (citizensList != null)
        {
            Debug.Log("Citizens list fetched successfully. Number of citizens: " + citizensList.Count);

            // Loop through each citizen in the list
            foreach (Person citizen in citizensList)
            {
                Debug.Log("Creating button for citizen: " + citizen.name);

                // Instantiate the button prefab
                Button newButton = Instantiate(buttonPrefab);
                
                // Set the parent to be the panel
                newButton.transform.SetParent(CitizensPanel.transform, false);
                if(citizen.happinessPercentage>=70)
                {
                newButton.GetComponent<Image>().color = Color.green;
                }
                else
                {
                newButton.GetComponent<Image>().color = Color.red;
                }


                // Find the Text component within the button and set the text
                TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = citizen.name;
                }

                // Optionally, add a listener to handle button click events
                newButton.onClick.AddListener(() => OnCitizenButtonClicked(citizen));
            }
        }
        else
        {
            Debug.LogError("citizensList is null. Ensure the manager and City component are set up correctly.");
        }
    }

    // Handler for button click events
    void OnCitizenButtonClicked(Person citizen)
    {
        Debug.Log("Button clicked for citizen: " + citizen.name);
        // Add additional logic to handle the button click event
        DetailPanel.SetActive(true);
        CitizensPanel.SetActive(false);
        infoText.text=citizen.name + "\n";
        infoText.text+=citizen.happinessPercentage + "\n";

    }

    // Update is called once per frame
    void Update()
    {
        // Currently unused, but you can use this for future updates
    }
}
