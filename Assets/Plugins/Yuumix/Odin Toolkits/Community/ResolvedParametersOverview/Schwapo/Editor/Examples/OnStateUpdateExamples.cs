using Sirenix.OdinInspector;
using System;

namespace Yuumix.OdinToolkits.ThirdParty.ResolvedParametersOverview.Schwapo.Editor.Examples
{
    [ResolvedParameterExample]
    public class OnStateUpdateExamples_Action
    {
        [FoldoutGroup("Attribute Expression Example")]
        [InfoBox("@\"Last Update: \" + lastUpdate")]
        [OnStateUpdate("@lastUpdate = DateTime.Now")]
        public string AttributeExpressionExample;

        DateTime lastUpdate;

        [FoldoutGroup("Method Name Example")]
        [InfoBox("@\"Last Update: \" + lastUpdate")]
        [OnStateUpdate("OnStateUpdate")]
        public string MethodNameExample;

        void OnStateUpdate()
        {
            lastUpdate = DateTime.Now;
        }
    }
    // End
}
