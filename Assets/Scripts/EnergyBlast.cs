using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlast : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float projectile = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (GetComponent<EnergyHandling>().currentEnergy > projectile)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        GetComponent<EnergyHandling>().ReduceEnergy(projectile);
    }
}