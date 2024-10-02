using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class City : MonoBehaviour
{
        public TMP_Text NotifText;
    public List<Person> citizensList;
    public List<House> housesList;

    PersonCreator creator;
    public List<string> academicNotif;
    public List<string> happinessNotif;
    public List<string> laboralNotif;
    public List<string> creativeNotif;


    // Start is called before the first frame update
    void Start()
    {
        // Get reference to PersonCreator component
        creator = GetComponent<PersonCreator>();

        // Initialize the list
        citizensList = new List<Person>();

        // Generate persons and add them to the list
        for (int i = 0; i < 10; i++)
        {
            // Call the GeneratePerson method from PersonCreator
            Person newPerson = creator.GeneratePerson();

            // Add the generated person to the list
            citizensList.Add(newPerson);
        }

        Debug.Log("there are " + citizensList.Count + " citizens");
        foreach (Person citizen in citizensList)
        {
            Debug.Log("## " + citizen.name + " ##");
            Debug.Log("Age: " + citizen.age);
            Debug.Log("Happiness %: " + citizen.happinessPercentage);
            if(citizen.hasGoodDay()){
                happinessNotif.Add("Citizen " + citizen.name + " has had a good day!");
            }
                happinessNotif.Add("Citizen " + citizen.name + " current happiness % is " + citizen.happinessPercentage);
                Debug.Log("city has " + happinessNotif.Count + " news");


            Debug.Log("Has " + citizen.bankAccount + " euros in the bank");
        }
        printHappinessNews();
    }

    // Update is called once per frame
    void Update()
    {

    }
        void printHappinessNews(){
        Debug.Log("city has " + happinessNotif.Count + " news");
        foreach(string notificationCity in happinessNotif)
        {
            NotifText.text += "\n" + notificationCity;
        }
    }
}
