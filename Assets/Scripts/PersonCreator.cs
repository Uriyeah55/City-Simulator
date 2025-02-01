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
    int randomName = Random.Range(1, 5);
    string namePerson = "Person"; // Default name

    if (randomName == 1) namePerson = "Tom";
    if (randomName == 2) namePerson = "Gem";
    if (randomName == 3) namePerson = "Uri the best";
    if (randomName == 4) namePerson = "Amanda";

    int randomAge = Random.Range(1, 100);
    int randomMoneyAccount = 0;

    // Generate random sex (1 = man, 2 = woman)
    int randomSex = Random.Range(1, 3);

    if (randomAge >= 18)
    {
        randomMoneyAccount = Random.Range(1, 10000);
    }

    int randomHappiness = Random.Range(0, 101);

    // Create new instance of Person class
     Person newPerson = ScriptableObject.CreateInstance<Person>();  // Create instance


    // Assign generated attributes to the Person instance
    newPerson.name = namePerson;
    newPerson.age = randomAge;
    newPerson.bankAccount = randomMoneyAccount;
    newPerson.sex = randomSex;
    newPerson.happinessPercentage = randomHappiness;

    // Log the person details in a readable format
    Debug.Log($"Created person: {newPerson.name}");
    Debug.Log($"Age: {newPerson.age}");
    Debug.Log($"Sex: {(newPerson.sex == 1 ? "Man" : "Woman")}");
    Debug.Log($"Bank Account Balance: {newPerson.bankAccount} euros");
    Debug.Log($"Happiness: {newPerson.happinessPercentage}%");

    // Return the newly generated Person instance
    return newPerson;
}

}
