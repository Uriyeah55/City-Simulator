using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public string name;
    public bool isDead;
    public string job;
    public bool hasJob;
    public int age;
    public int bankAccount;
    public int salary;
    public int sex;
    public int healthPercentage;
    public int happinessPercentage;
    public bool isOwningHome;
    House ownedHouse;
    public List<string> healthNotifications;
    public List<string> economicNotifications;
    public List<string> happinnessNotifications;



    // Start is called before the first frame update
    void Start()
    {
        if(!isDead)
        {
            checkCitizenRoutine();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void work()
    {
        if(hasJob)
        {
            happinessPercentage-= 5;
            if(isOwningHome)
            {
                ownedHouse.payMortgage(salary/2);
            }
        }
    }
    public bool hasGoodDay()
    {
        int randomGoodDay = Random.Range(1, 5);
        bool returnBool=false;
        if(randomGoodDay==1)
        {
            happinessPercentage+=15;
            returnBool=true;
            if(happinessPercentage>=100)
            {
                happinessPercentage=100;
            }
        }
        return returnBool;
    }
    void home()
    {
        if(age>18)
        {

        }
    }
    void checkCitizenRoutine()
    {
    work();
    hasGoodDay();
    }
}
