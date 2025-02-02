using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessCalculator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public float CalculateAverageHappiness(List<Person> citizenList)
    {
        if (citizenList.Count == 0) return 0f;

        float totalHappiness = 0f;
        foreach (Person citizen in citizenList)
        {
            totalHappiness += citizen.happinessPercentage;
        }

        return totalHappiness / citizenList.Count;
    }

}
