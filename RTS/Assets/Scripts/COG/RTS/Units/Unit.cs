using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace COG.RTS.Units
{
    [CreateAssetMenu(fileName = "Unit", menuName = "RTS/Units/Unit", order = 1)]
    public class Unit : ScriptableObject
    {
        public FloatReference Health;
        public FloatReference RateOfFire;
        public AttackType AttackType;
        public FloatReference AttackRange;
        public FloatReference ProjectileSpeed;
        public CombatType CombatType;
        public ArmourType ArmourType;
        public DamageType DamageType;
        public FloatReference DamageAmount;
        // Splash Info
        public FloatReference MovementSpeed;
        public FloatReference SightRange;
        public ushort Cost;
        public FloatReference BuildTime;
    }
}
