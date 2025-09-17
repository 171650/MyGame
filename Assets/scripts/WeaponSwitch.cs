using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedweapon = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousselectedweapon = selectedweapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedweapon >= transform.childCount - 1)
            {
                selectedweapon = 0;
            }
            else
            {
                selectedweapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedweapon <= 0)
            {
                selectedweapon = transform.childCount - 1;
            }
            else
            {
                selectedweapon--;
            }
        }

        if (previousselectedweapon != selectedweapon)
        {
            selectweapon();
        }
    }
    void selectweapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedweapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
