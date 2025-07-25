using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Yuumix.OdinToolkits.Core;
using Yuumix.OdinToolkits.Editor.Shared;

namespace Yuumix.OdinToolkits.Editor
{
    public class DirectoryTreeGenToolSO : OdinEditorScriptableSingleton<DirectoryTreeGenToolSO>, IOdinToolkitsReset
    {
        public static MultiLanguageData DirectoryTreeGenToolMenuPathData =
            new MultiLanguageData("目录树生成工具", "Directory Tree Generate Tool");

        public static string[] FileExtensionsFilterArray =
        {
            ".meta",
            ".asmdef"
        };

        public MultiLanguageHeaderWidget headerWidget =
            new MultiLanguageHeaderWidget(DirectoryTreeGenToolMenuPathData.GetChinese(),
                DirectoryTreeGenToolMenuPathData.GetEnglish(),
                "根据文件夹路径，解析其子路径文件夹及文件，生成不同种类的目录树",
                "Based on the folder path, parse the sub-path folders and files within it, " +
                "and generate different types of directory trees.");

        [FolderPath(RequireExistingPath = true, AbsolutePath = true)]
        [MultiLanguageTitle("选择的文件夹路径", "Folder Path")]
        [HideLabel]
        [CustomContextMenu("Odin Toolkits Reset", "OdinToolkitsReset")]
        public string folderPath;

        [MultiLanguageTitle("结果显示的最大深度", "Result Max Depth")]
        [HideLabel]
        [MinValue(2)]
        [CustomContextMenu("OdinToolkitsReset", "OdinToolkitsReset")]
        public int maxDepth;

        [MultiLanguageTitle("生成命令选择", "Generate Command Selector")]
        [HideLabel]
        public GenerateCommandSO command;

        [MultiLanguageTitleGroup("TG", "操作按钮", "Operator Buttons")]
        [HorizontalGroup("TG/B")]
        [MultiLanguageButton("解析路径", "Analyze Folder Path", ButtonSizes.Large)]
        public void Analyze()
        {
            if (!Directory.Exists(folderPath))
            {
                YuumixLogger.EditorLogError("路径不存在");
                return;
            }

            DirectoryAnalysisData.CurrentRootPath = folderPath;
            _directoryAnalysisData = DirectoryAnalysisData.FromDirectoryInfo(new DirectoryInfo(folderPath));
        }

        [MultiLanguageTitleGroup("TG", "操作按钮", "Operator Buttons")]
        [HorizontalGroup("TG/B")]
        [MultiLanguageButton("执行生成命令", "Execute Generate Command", ButtonSizes.Large)]
        public void GenerateProjectStructureTree()
        {
            if (command)
            {
                resultText = command.Generate(_directoryAnalysisData, maxDepth);
            }
        }

        [PropertyOrder(50)]
        [TextArea(3, 15)]
        [MultiLanguageTitle("结果", "Result")]
        [HideLabel]
        public string resultText;

        [PropertyOrder(100)]
        [MultiLanguageTitle("过程数据", "Process Data")]
        [ReadOnly]
        [OdinSerialize]
        DirectoryAnalysisData _directoryAnalysisData;

        public void OdinToolkitsReset()
        {
            folderPath = null;
            maxDepth = 2;
            resultText = null;
            command = null;
            _directoryAnalysisData = null;
        }
    }
}
