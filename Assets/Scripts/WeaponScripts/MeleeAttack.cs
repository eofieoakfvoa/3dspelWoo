using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeAttack : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public string Description;
    [SerializeField] public AnimationClip AttackAnimation;
    [Serializable]
    public class WeaponDebuffs
    {
        public GameObject Origin;
        public int Chance;
    }
    [SerializeField] private WeaponDebuffs[] M_Debuffs;

}
