using UnityEngine;

public class SC_WeaponManager : MonoBehaviour
{
    public Camera playerCamera;
    public SC_Weapon primaryWeapon;
    public SC_Weapon secondaryWeapon;
    //public SC_Weapon superWeapon;

    [HideInInspector]
    public SC_Weapon selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //At the start we enable the primary weapon and disable the secondary
        primaryWeapon.ActivateWeapon(true);
        secondaryWeapon.ActivateWeapon(false);
        //superWeapon.ActivateWeapon(false);
        selectedWeapon = primaryWeapon;
        primaryWeapon.manager = this;
        secondaryWeapon.manager = this;
        //superWeapon.manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Select secondary weapon when pressing 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            primaryWeapon.ActivateWeapon(false);
            secondaryWeapon.ActivateWeapon(true);
            //superWeapon.ActivateWeapon(false);
            selectedWeapon = secondaryWeapon;
        }

        //Select primary weapon when pressing 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            primaryWeapon.ActivateWeapon(true);
            secondaryWeapon.ActivateWeapon(false);
            //superWeapon.ActivateWeapon(false);
            selectedWeapon = primaryWeapon;
        }
        //Select super weapon when pressing 3
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    primaryWeapon.ActivateWeapon(false);
        //    secondaryWeapon.ActivateWeapon(false);
        //    superWeapon.ActivateWeapon(true);
        //    selectedWeapon = superWeapon;
        //}
    }
}