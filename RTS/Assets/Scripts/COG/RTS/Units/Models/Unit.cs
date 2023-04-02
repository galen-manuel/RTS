using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

namespace COG.RTS.Units
{
    [CreateAssetMenu(fileName = "Unit", menuName = "RTS/Units/Unit", order = 1)]
    public class Unit : ScriptableObject
    {
        public FloatReference MaxHealth;
        public FloatReference RateOfFire;
        public AttackType AttackType;
        public FloatReference AttackRange;
        public FloatReference ProjectileSpeed;
        public CombatType CombatType;
        public ArmourType ArmourType;
        public DamageType DamageType;
        public FloatReference DamageAmount;
        public SplashInfo SplashInfo;
        public FloatReference MovementSpeed;
        public FloatReference SightRange;
        public ushort Cost;
        public FloatReference BuildTime;
    }
}
