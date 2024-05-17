using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeapon : WeaponClass
{
    [Serializable]
    private class ComboAttackmm
    {
        public MeleeAttack meleeAttack;
    }
    [SerializeField] private ComboAttackmm[] M_ComboAttack;
    


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
    public void Init()
    {
        ComboLength = M_ComboAttack.Length;

        hasInit = true;
    }
    bool hasInit = false;
    
    public override void LeftClickAction()
    {
        if (!hasInit)
        {
            Init();
        }
        print(ComboLength);
        CurrentComboState = ComboState.Current;
        if (!Debounce)
        {
            

            if (CurrentComboState == ComboState.Current)
            {
                Debug.Log(M_ComboAttack[currentIndex].meleeAttack.Name);
                //play animation när den är klar så ska det bli ended
                CurrentComboState = ComboState.Ended;
            }
            if (CurrentComboState == ComboState.Ended)
            {
                //start SpaceBetweenAttacks timern så man kan klicka inom 0.5 sekunder för att fortsätta kombon annars resettar den 
                Debounce = false;
            }

            if (currentIndex <= ComboLength - 2) // -2 för någon anledning, -1 eftersom length är automatiskt +1 än vad det ska vara, men vart den extra kommer ifrån vet jag ej
            {
                print("The combo Length is "+ComboLength);
                print("The current index is "+currentIndex);
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
