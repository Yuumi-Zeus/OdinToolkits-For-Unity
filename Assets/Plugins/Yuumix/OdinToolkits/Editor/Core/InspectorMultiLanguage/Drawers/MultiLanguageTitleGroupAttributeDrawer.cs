using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Yuumix.OdinToolkits.Core;

namespace Yuumix.OdinToolkits.Editor.Core
{
    public class MultiLanguageTitleGroupAttributeDrawer : OdinGroupDrawer<MultiLanguageTitleGroupAttribute>
    {
        public ValueResolver<string> TitleHelper;
        public ValueResolver<string> SubtitleHelper;

        protected override void Initialize()
        {
            ReloadResolver();
            InspectorMultiLanguageSetting.OnLanguageChange -= ReloadResolver;
            InspectorMultiLanguageSetting.OnLanguageChange += ReloadResolver;
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            InspectorProperty property = Property;
            MultiLanguageTitleGroupAttribute attribute = Attribute;
            if (property != property.Tree.GetRootProperty(0))
            {
                EditorGUILayout.Space();
            }

            SirenixEditorGUI.Title(TitleHelper.GetValue(), SubtitleHelper.GetValue(),
                (TextAlignment)attribute.TitleAlignment, attribute.HorizontalLine, attribute.BoldTitle);
            GUIHelper.PushIndentLevel(EditorGUI.indentLevel + (attribute.Indent ? 1 : 0));
            for (var index = 0; index < property.Children.Count; ++index)
            {
                InspectorProperty child = property.Children[index];
                child.Draw(child.Label);
            }

            GUIHelper.PopIndentLevel();
        }

        void ReloadResolver()
        {
            TitleHelper = ValueResolver.GetForString(Property, Attribute.TitleData);
            SubtitleHelper = ValueResolver.GetForString(Property, Attribute.SubtitleData);
        }
    }
}
