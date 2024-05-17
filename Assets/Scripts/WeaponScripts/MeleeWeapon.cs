using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeapon : WeaponClass
{


    [SerializeField]
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    public GameObject HurtBox;
    enum ComboState
    {
        None = 0,
        Current,
        Ended
    }
    ComboState CurrentComboState;

    protected bool Debounce = false;
    private float BreathingSpaceBetweenAttack;
    private Coroutine coroutine;


    public int ComboLength;
    public List<int> ComboAttacks;
    public int currentIndex = 0;
    public override void LeftClickAction()
    {
        CurrentComboState = ComboState.Current;
        if (!Debounce)
        {
            

            if (CurrentComboState == ComboState.Current)
            {
                Debug.Log("Current combo attack: " + ComboAttacks[currentIndex]);
                CurrentComboState = ComboState.Ended;
            }
            if (CurrentComboState == ComboState.Ended)
            {
                //start timer
                Debounce = false;
            }

            if (currentIndex < ComboAttacks.Count -1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }
    }

    public override void RightClickAction()
    {
        Debug.Log("Right Click");
    }
}
