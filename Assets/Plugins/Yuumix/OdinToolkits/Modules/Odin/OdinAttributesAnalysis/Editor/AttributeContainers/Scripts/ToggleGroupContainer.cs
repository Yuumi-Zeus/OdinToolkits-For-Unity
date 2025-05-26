using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class ToggleGroupContainer : AbsContainer
    {
        protected override string SetHeader() => "ToggleGroup";

        protected override string SetBrief() => "将任意 Property 以类似 FoldoutGroup 可折叠的形式分组绘制，同时有一个 Toggle 值可以控制 Enable 或者 Disable";

        protected override List<string> SetTip() =>
            new List<string>
                { "bool 类型控制变量要包含在 ToggleGroup 内部" };

        protected override List<ParamValue> SetParamValues() =>
            new List<ParamValue>
            {
                new ParamValue
                {
                    returnType = "string",
                    paramName = "toggleMemberName",
                    paramDescription = "bool 类型的成员名，用于控制开启焦点获取和关闭，" + DescriptionConfigs.SupportAllResolver
                },
                new ParamValue
                {
                    returnType = "float",
                    paramName = "order",
                    paramDescription = "不同 Group 之间排序，值越大越靠后，默认为 0"
                },
                new ParamValue
                {
                    returnType = "string",
                    paramName = "groupTitle",
                    paramDescription = "分组标题以及路径"
                },
                new ParamValue
                {
                    returnType = "bool",
                    paramName = "CollapseOthersOnExpand",
                    paramDescription = "是否展开时关闭其他分组，默认为 true"
                }
            };

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(ToggleGroupExample));
    }
}
