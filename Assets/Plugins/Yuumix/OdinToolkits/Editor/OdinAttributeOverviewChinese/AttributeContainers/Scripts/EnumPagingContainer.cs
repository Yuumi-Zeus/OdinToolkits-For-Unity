using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class EnumPagingContainer : AbsContainer
    {
        protected override string SetHeader() => "EnumPaging";

        protected override string SetBrief() => "作用于枚举类型，绘制一个可循环的枚举按钮";

        protected override List<string> SetTip() =>
            new List<string>
            {
                "可以和其他结合使用，比如可以改变 Unity 编辑器当前选择的工具"
            };

        protected override List<ParamValue> SetParamValues() => new List<ParamValue>();

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(EnumPagingExample));
    }
}
