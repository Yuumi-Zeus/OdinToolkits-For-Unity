using Sirenix.OdinInspector;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts
{
    [IsChineseAttributeExample]
    public class HideReferenceObjectPickerExample : ExampleOdinScriptableObject
    {
        [Title("Hidden Object Pickers")]
        [HideReferenceObjectPicker]
        [Indent]
        public MyCustomReferenceType OdinSerializedProperty1 = new MyCustomReferenceType();

        [HideReferenceObjectPicker]
        [Indent]
        public MyCustomReferenceType OdinSerializedProperty2 = new MyCustomReferenceType();

        [Title("Shown Object Pickers")]
        [Indent]
        public MyCustomReferenceType OdinSerializedProperty3 = new MyCustomReferenceType();

        [Indent]
        public MyCustomReferenceType OdinSerializedProperty4 = new MyCustomReferenceType();

        // 可以直接在类上使用
        // [HideReferenceObjectPicker]
        public class MyCustomReferenceType
        {
            public int A;
            public int B;
            public int C;
        }
    }
}
