using Plugins.YOGA.OdinToolkits.Modules.OdinAttributesAnalysis.Common.Editor;
using Sirenix.OdinInspector;
using Yuumix.OdinToolkits.Common.Runtime;
using Yuumix.OdinToolkits.Modules.Utilities.YuumiEditor;

namespace Plugins.YOGA.OdinToolkits.Modules.OdinAttributesAnalysis.Editor.AttributePreviewExamples.Scripts
{
    [IsChineseAttributeExample]
    public class ChildGameObjectOnlyExample : ExampleScriptableObject
    {
        private static string Path => ProjectEditorUtility
            .Paths.GetTargetFolderPath("RuntimeExamples",
                "OdinToolkits") + "/ChildGameObjectOnly";

        [DisplayAsString(fontSize: 12, overflow: false)]
        [HideLabel]
        [ShowInInspector]
        [EnableGUI]
        public string Tip => "提示: " + "ChildGameObjectOnly 和场景中物体有关，需要运行时场景验证";

        [DisplayAsString(fontSize: 12, overflow: false)]
        [HideLabel]
        [ShowInInspector]
        [EnableGUI]
        public string PathTip => "文件夹路径为: " + Path;

        [Button("跳转到 Example 文件夹", ButtonSizes.Large)]
        public void SelectionFolder()
        {
            OdinEditorLog.Log("ChildGameObjectOnly Runtime Example 文件夹路径为: " + Path);
            ProjectEditorUtility.PingAndSelectAsset(Path);
        }
    }
}