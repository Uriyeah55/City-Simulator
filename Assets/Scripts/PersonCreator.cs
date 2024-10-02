using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Person GeneratePerson()
    {
        // Generate random attributes
        int randomName=Random.Range(1, 5);
        string namePerson = "Person"; // Default name

        if (randomName == 1)
        {
            namePerson = "Tom";
        }
        if (randomName == 2)
        {
            namePerson = "Gem";

        }
        if (randomName == 3)
        {
            namePerson = "Uri the best";
        }
        if (randomName == 4)
        {
            namePerson = "Amanda";

        }
        int randomAge = Random.Range(1, 100);
        int randomMoneyAccount = 0;

        // We will get results from 1 (man) to 2 (woman)
        int randomSex = Random.Range(1, 3);

        if (randomAge >= 18)
        {
            randomMoneyAccount = Random.Range(1, 10000);
        }

        int randomHappiness = Random.Range(0, 101);

        // Create new instance of Person class
        Person newPerson = new Person();

        // Assign generated attributes to the Person instance
        newPerson.name = namePerson;
        newPerson.age = randomAge;
        newPerson.bankAccount = randomMoneyAccount;
        newPerson.sex = randomSex;
        newPerson.happinessPercentage = randomHappiness;

        // Return the newly generated Person instance
        return newPerson;
    }
}
