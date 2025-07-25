using Yuumix.OdinToolkits.Shared;

namespace Yuumix.OdinToolkits.Editor.Shared
{
    /// <summary>
    /// 和版本有关的特殊字符串，包括 Changelog 和 Roadmap
    /// </summary>
    public static class ChangeCategory
    {
        public static string Added => "Added: ".ToGreen();
        public static string Changed => "Changed: ".ToYellow();
        public static string Deprecated => "Deprecated: ".ToRed();
        public static string Removed => "Removed: ".ToRed();
        public static string Fixed => "Fixed: ".ToGreen();
        public static string Security => "Security: ".ToRed();
        public static string Roadmap => "Roadmap: ".ToGreen();
    }
}
