using System.Collections.Generic;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Common.Editor;
using Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts;

namespace Yuumix.OdinToolkits.Modules.Odin.OdinAttributesAnalysis.Editor.AttributeContainers.Scripts
{
    public class ShowDrawerChainContainer : AbsContainer
    {
        protected override string SetHeader() => "ShowDrawerChain";

        protected override string SetBrief() => "用于调试查看 Property 的绘制链，查看具体绘制行为";

        protected override List<string> SetTip() => new List<string>();

        protected override List<ParamValue> SetParamValues() => new List<ParamValue>();

        protected override string SetOriginalCode() => ReadCodeWithoutNamespace(typeof(ShowDrawerChainExample));
    }
}
