using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class PropertyTooltipContainer : AbsContainer
    {
        protected override string SetHeader() => "PropertyTooltip";

        protected override string SetBrief() => "给任意 Property 添加 Tooltip";

        protected override List<string> SetTip() =>
            new List<string>
            {
                "任意 Property 包括字段，显示的属性，绘制的方法"
            };

        protected override List<ParamValue> SetParamValues() =>
            new List<ParamValue>
            {
                new ParamValue
                {
                    returnType = "string",
                    paramName = "Tooltip",
                    paramDescription = "Tooltip 文本，" + DescriptionConfigs.SupportAllResolver
                }
            };

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(PropertyTooltipExample));
    }
}
