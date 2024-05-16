using System.Collections;
using System.Collections.Generic;
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
    public int ComboLength;
    enum ComboState
    {
        None = 0,
        Current,
        Ended
    }
    ComboState CurrentComboState;
    public List<int> ComboAttacks;
    private bool Debounce = false;
    private float BreathingSpaceBetweenAttack;

    public override void LeftClickAction()
    {
        CurrentComboState = ComboState.Current;
        if (!Debounce)
        {
            for (int i = 0; i < ComboLength; i++)
            {
                if (CurrentComboState == ComboState.Current)
                {
                    Debounce = true;
                    print(ComboAttacks[i]);
                    CurrentComboState = ComboState.Ended;
                }
                if (CurrentComboState == ComboState.Ended)
                {
                    Debounce = false;
                }
            }
        }
    }

    IEnumerator CountDown()
    {

    yield return new WaitForSeconds(1);

    BreathingSpaceBetweenAttack--;

    }

    public override void RightClickAction()
    {
        Debug.Log("Right Click");
    }
}
