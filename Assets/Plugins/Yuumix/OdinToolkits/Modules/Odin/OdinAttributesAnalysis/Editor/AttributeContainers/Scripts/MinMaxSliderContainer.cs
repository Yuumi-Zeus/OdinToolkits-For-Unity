using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class MinMaxSliderContainer : AbsContainer
    {
        protected override string SetHeader() => "MinMaxSlider";

        protected override string SetBrief() => "把 Vector2 以滑动条的样式绘制";

        protected override List<string> SetTip() =>
            new List<string>
            {
                "左边的值代表 Vector2 的 X，右边的值代表 Vector2 的 Y，可以设置一个范围，但是限制了 X 必须小于等于 Y",
                "实际运用中，把 MinMaxSlider 对应的 Vector2 变量作为一个范围界定值，而不是直接参与运算的值"
            };

        protected override List<ParamValue> SetParamValues() =>
            new List<ParamValue>
            {
                new ParamValue
                {
                    returnType = "float",
                    paramName = "minValue",
                    paramDescription = "最小值，" + DescriptionConfigs.SupportAllResolver
                },
                new ParamValue
                {
                    returnType = "float",
                    paramName = "maxValue",
                    paramDescription = "最大值，" + DescriptionConfigs.SupportAllResolver
                },
                new ParamValue
                {
                    returnType = "bool",
                    paramName = "showFields",
                    paramDescription = "如果为 true，将会绘制值的范围数值"
                }
            };

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(MinMaxSliderExample));
    }
}
