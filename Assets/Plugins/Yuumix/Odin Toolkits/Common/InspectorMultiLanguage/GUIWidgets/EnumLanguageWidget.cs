using Sirenix.OdinInspector;
using System;

namespace Yuumix.OdinToolkits.Common.InspectorMultiLanguage
{
    [Serializable]
    [InlineProperty]
    [HideLabel]
    public class EnumLanguageWidget
    {
        [EnableGUI]
        [ShowInInspector]
        [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        public InspectorMultiLanguageManagerSO LanguageMultiLanguageManager => InspectorMultiLanguageManagerSO.Instance;
    }
}
