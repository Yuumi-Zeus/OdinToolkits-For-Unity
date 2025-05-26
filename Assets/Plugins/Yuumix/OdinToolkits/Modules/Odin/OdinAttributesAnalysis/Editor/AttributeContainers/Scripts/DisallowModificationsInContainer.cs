using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class DisallowModificationsInContainer : AbsContainer
    {
        protected override string SetHeader() => "DisallowModificationsIn";

        protected override string SetBrief() => "禁用 Property，防止进行修改并启用验证，如果进行了修改，则提供错误消息";

        protected override List<string> SetTip() =>
            new List<string>
            {
                "代码可以修改，但是会出现错误信息，[DisableIn] 仅仅禁用成员，代码修改不会报错"
            };

        protected override List<ParamValue> SetParamValues() => new List<ParamValue>();

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(DisallowModificationsInExample));
    }
}
