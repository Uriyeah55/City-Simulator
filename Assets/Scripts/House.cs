using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    int flats;
    bool fullyPaid=false;
    int fullValue;
    int valuePaid=0;
    Person owner;



    public void payMortgage(int amount){
        valuePaid += amount;
        Debug.Log("Citizen " + owner.name + " has paid " + amount + " from the mortgage. Remaining " + (fullValue = valuePaid));
        if(valuePaid >= fullValue)
        {
            Debug.Log("house paid!");
        }
    }
}
