using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class InlineEditorContainer : AbsContainer
    {
        protected override string SetHeader() => "InlineEditor";

        protected override string SetBrief() => "立刻绘制另外一个类的 Editor 样式";

        protected override List<string> SetTip() => new List<string>();

        protected override List<ParamValue> SetParamValues() =>
            new List<ParamValue>
            {
                new ParamValue
                {
                    returnType = "InlineEditorModes",
                    paramName = "inlineEditorMode",
                    paramDescription = "显示模式，默认为 InlineEditorModes.GUIOnly"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorModes 枚举",
                    paramName = "InlineEditorModes.GUIAndHeader",
                    paramDescription = "显示 GUI 以及 Inspector 界面的 Header 部分"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorModes 枚举",
                    paramName = "InlineEditorModes.GUIAndPreview",
                    paramDescription = "显示 GUI 以及 Inspector 界面的 Preview 预览部分"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorModes 枚举",
                    paramName = "InlineEditorModes.SmallPreview",
                    paramDescription = "显示 SmallPreview 小型预览窗口"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorModes 枚举",
                    paramName = "InlineEditorModes.LargePreview",
                    paramDescription = "显示 LargePreview 大型预览窗口"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorModes 枚举",
                    paramName = "InlineEditorModes.FullEditor",
                    paramDescription = "完全显示"
                },
                new ParamValue
                {
                    returnType = "InlineEditorObjectFieldModes",
                    paramName = "objectFieldMode",
                    paramDescription = "绘制模式，默认为 InlineEditorObjectFieldModes.Boxed"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorObjectFieldModes 枚举",
                    paramName = "InlineEditorObjectFieldModes.Foldout",
                    paramDescription = "显示在 Foldout 模式下"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorObjectFieldModes 枚举",
                    paramName = "InlineEditorObjectFieldModes.Hidden",
                    paramDescription = "不为空时隐藏 ObjectField"
                },
                new ParamValue
                {
                    returnType = ">>> InlineEditorObjectFieldModes 枚举",
                    paramName = "InlineEditorObjectFieldModes.CompletelyHidden",
                    paramDescription = "彻底隐藏，必须代码中赋值，否则一旦为 null，面板中无法赋值"
                }
            };

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(InlineEditorExample));
    }
}
