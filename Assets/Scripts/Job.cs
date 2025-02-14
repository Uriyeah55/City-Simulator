using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    public string jobTitle;
    public int salary;  // Monthly salary
    public int workHoursPerDay;
    public int happinessImpact; // Happiness change per workday

    public Job(string title, int salary, int hours, bool partTime, int happinessEffect)
    {
        this.jobTitle = title;
        this.salary = salary;
        this.workHoursPerDay = hours;
        this.isPartTime = partTime;
        this.happinessImpact = happinessEffect;
    }
}
