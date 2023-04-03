using System;
using System.Collections;
using System.Reflection.Emit;
using Sirenix.OdinInspector;

namespace COG.RTS
{
    [Serializable]
    public class FloatReference
    {
        [HorizontalGroup("Test"), ValueDropdown("options"), HideLabel]
        public bool UseConstant = true;
        [HorizontalGroup("Test")]
        [ShowIf("UseConstant")]
        [HideLabel]
        public float ConstantValue;
        [HorizontalGroup("Test")]
        [HideIf("UseConstant")]
        [HideLabel]
        public FloatVariable Variable;

        public float Value => UseConstant ? ConstantValue : Variable.Value;

        private IEnumerable options = new ValueDropdownList<bool>()
                                      {
                                          { "Constant", true},
                                          { "Reference", false}
                                      };
    }
}
