using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public Weapon SelectedWeapon { get; private set; }

    private int selectedWeaponIndex = 0;
    private void Awake()
    {
        SelectedWeapon = gameObject.GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        int prevWeaponIndex = selectedWeaponIndex;

        // колёсико вверх
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeaponIndex >= transform.childCount - 1)
                selectedWeaponIndex = 0;
            else
                selectedWeaponIndex++;
        }
        // колёсико вниз
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeaponIndex <= 0)
                selectedWeaponIndex = transform.childCount - 1;
            else
                selectedWeaponIndex--;
        }

        if (prevWeaponIndex != selectedWeaponIndex)
        {
            SelectedWeapon = SelectWeapon(); 
        }
    }

    Weapon SelectWeapon()
    {
        Weapon newWeapon = null;

        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
                newWeapon = weapon.gameObject.GetComponent<Weapon>();
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }

        return newWeapon;
    }
     
}
