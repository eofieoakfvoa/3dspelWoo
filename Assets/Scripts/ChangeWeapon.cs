using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ! Finslipa
public class ChangeWeapon : MonoBehaviour
{
    //lägg detta i en Character controller script ocksÅ?
    [SerializeField] WeaponAttachment AttachmentScript;
    [SerializeField] GameObject Weapon1;
    [SerializeField] GameObject Weapon2;
    private Vector3 PreviousMousePosition;
    private WeaponClass weaponClass1;
    private WeaponClass weaponClass2;
    void Start()
    {
        weaponClass1 = Weapon1.GetComponent<WeaponClass>();
        weaponClass2 = Weapon2.GetComponent<WeaponClass>();
    }

    void Update()
    {
        // * lägg till en Debounce
        if (Input.GetKeyDown(KeyCode.C))
        {
            //öppna Weapon Choice UI
            PreviousMousePosition = Input.mousePosition;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Vector3 mousePosChange = Input.mousePosition - PreviousMousePosition;
            print(mousePosChange);
            Cursor.lockState = CursorLockMode.Locked;
            if (mousePosChange.x > 200)
            {

                AttachmentScript.AttachWeapon(Weapon1, weaponClass1);
                
            }
            else if (mousePosChange.x < -200)
            {
                AttachmentScript.AttachWeapon(Weapon2, weaponClass2);

            }
        }
    }
}
