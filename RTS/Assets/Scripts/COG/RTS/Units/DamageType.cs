using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Units
{
    [CreateAssetMenu(fileName = "DamageType", menuName = "RTS/Units/DamageType", order = 5)]
    public class DamageType : ScriptableObject
    {
        public List<DamageArmourPair> DamageArmourPairs;
    }
}
