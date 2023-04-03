using UnityEngine;

namespace COG.RTS 
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "RTS/Variables/Float", order = 1)]
    public class FloatVariable : ScriptableObject
    {
        public float Value;
    }
}
