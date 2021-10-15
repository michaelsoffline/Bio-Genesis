using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyHandling : MonoBehaviour
{
    public Image energyBar;
    public float myEnergy;

    private float currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = myEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergy < myEnergy)
        {
            energyBar.fillAmount = Mathf.MoveTowards(energyBar.fillAmount, 1f, Time.deltaTime * 0.01f);
            currentEnergy = Mathf.MoveTowards(currentEnergy / myEnergy, 1f, Time.deltaTime * 0.01f) * myEnergy;
        }

        if(currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }

    public void ReduceEnergy(float energy)
    {
        currentEnergy -= energy;
        energyBar.fillAmount -= energy / myEnergy;
    }
}
