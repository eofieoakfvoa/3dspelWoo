using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] WeaponAttatchment AttachmentScript;
    [SerializeField] GameObject Weapon1;
    [SerializeField] GameObject Weapon2;
    private Vector3 PreviousMousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //öppna Weapon Choice UI
                PreviousMousePosition = Input.mousePosition;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Vector3 mousePosChange = Input.mousePosition - PreviousMousePosition;
            print(mousePosChange);
            if (mousePosChange.x > 0)
            {
                AttachmentScript.AttachWeapon(Weapon1);
            }
            else if (mousePosChange.x < 0)
            {
                AttachmentScript.AttachWeapon(Weapon2);

            }
        }
    }
}
