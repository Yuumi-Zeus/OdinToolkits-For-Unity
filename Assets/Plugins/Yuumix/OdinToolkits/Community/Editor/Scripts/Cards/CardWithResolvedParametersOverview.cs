using Community.Schwapo.Editor;
using UnityEngine;
using Yuumix.OdinToolkits.Core;

namespace Yuumix.OdinToolkits.Community.Editor
{
    public class CardWithResolvedParametersOverview : CommunityCardSO<CardWithResolvedParametersOverview>
    {
        protected override MultiLanguageDisplayAsStringWidget GetCardHeader() =>
            new MultiLanguageDisplayAsStringWidget(
                "Odin 特性中被解析的参数总览",
                "Resolved Parameters Overview");

        protected override Author GetAuthor() => new Author("Schwapo", "https://github.com/schwapo");

        protected override MultiLanguageDisplayAsStringWidget GetIntroduction() =>
            new MultiLanguageDisplayAsStringWidget(
                "可以查看 Odin Inspector 所有自带的特性中能够进行字符串解析的参数以及用法示例。",
                "You can view all the parameters that can perform string parsing among the built-in attributes of Odin Inspector, " +
                "as well as their usage examples.");

        protected override void OpenWindowOrPingFolder()
        {
            ResolvedParametersOverviewWindow.Open();
        }

        protected override void OpenModuleLink()
        {
            Application.OpenURL("https://github.com/schwapo/Odin-Resolved-Parameters-Overview");
        }
    }
}
