using System;
using UnityEngine;

namespace COG.RTS.Units
{
    [Serializable]
    public class DamageArmourPair
    {
        public ArmourType ArmourType;
        [Range(0, 150)]
        public float DamagePercentage;
    }
}
