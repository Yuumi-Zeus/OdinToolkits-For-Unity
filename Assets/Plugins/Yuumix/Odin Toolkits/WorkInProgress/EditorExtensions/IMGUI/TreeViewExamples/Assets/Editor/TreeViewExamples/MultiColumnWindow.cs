using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Yuumix.OdinToolkits.Modules.LearnArchive.EditorExtensions.IMGUI.TreeViewExamples.Assets.Editor.TreeDataModel;
using Yuumix.OdinToolkits.Modules.LearnArchive.EditorExtensions.IMGUI.TreeViewExamples.Assets.Editor.TreeViewExamples.BackendData;

namespace Yuumix.OdinToolkits.Modules.LearnArchive.EditorExtensions.IMGUI.TreeViewExamples.Assets.Editor.TreeViewExamples
{
    internal class MultiColumnWindow : EditorWindow
    {
        [SerializeField]
        TreeViewState m_TreeViewState; // Serialized in the window layout file so it survives assembly reloading

        [SerializeField]
        MultiColumnHeaderState m_MultiColumnHeaderState;

        [NonSerialized]
        bool m_Initialized;

        MyTreeAsset m_MyTreeAsset;
        SearchField m_SearchField;

        Rect multiColumnTreeViewRect => new Rect(20, 30, position.width - 40, position.height - 60);

        Rect toolbarRect => new Rect(20f, 10f, position.width - 40f, 20f);

        Rect bottomToolbarRect => new Rect(20f, position.height - 18f, position.width - 40f, 16f);

        public MultiColumnTreeView treeView { get; private set; }

        void OnGUI()
        {
            InitIfNeeded();

            SearchBar(toolbarRect);
            DoTreeView(multiColumnTreeViewRect);
            BottomToolBar(bottomToolbarRect);
        }

        void OnSelectionChange()
        {
            if (!m_Initialized)
            {
                return;
            }

            var myTreeAsset = Selection.activeObject as MyTreeAsset;
            if (myTreeAsset != null && myTreeAsset != m_MyTreeAsset)
            {
                m_MyTreeAsset = myTreeAsset;
                treeView.treeModel.SetData(GetData());
                treeView.Reload();
            }
        }

        // [MenuItem("TreeView Examples/Multi Columns")]
        public static MultiColumnWindow GetWindow()
        {
            var window = GetWindow<MultiColumnWindow>();
            window.titleContent = new GUIContent("Multi Columns");
            window.Focus();
            window.Repaint();
            return window;
        }

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            var myTreeAsset = EditorUtility.InstanceIDToObject(instanceID) as MyTreeAsset;
            if (myTreeAsset != null)
            {
                var window = GetWindow();
                window.SetTreeAsset(myTreeAsset);
                return true;
            }

            return false; // we did not handle the open
        }

        void SetTreeAsset(MyTreeAsset myTreeAsset)
        {
            m_MyTreeAsset = myTreeAsset;
            m_Initialized = false;
        }

        void InitIfNeeded()
        {
            if (!m_Initialized)
            {
                // Check if it already exists (deserialized from window layout file or scriptable object)
                if (m_TreeViewState == null)
                {
                    m_TreeViewState = new TreeViewState();
                }

                var firstInit = m_MultiColumnHeaderState == null;
                var headerState = MultiColumnTreeView.CreateDefaultMultiColumnHeaderState(multiColumnTreeViewRect.width);
                if (MultiColumnHeaderState.CanOverwriteSerializedFields(m_MultiColumnHeaderState, headerState))
                {
                    MultiColumnHeaderState.OverwriteSerializedFields(m_MultiColumnHeaderState, headerState);
                }

                m_MultiColumnHeaderState = headerState;

                var multiColumnHeader = new MyMultiColumnHeader(headerState);
                if (firstInit)
                {
                    multiColumnHeader.ResizeToFit();
                }

                var treeModel = new TreeModel<MyTreeElement>(GetData());

                treeView = new MultiColumnTreeView(m_TreeViewState, multiColumnHeader, treeModel);

                m_SearchField = new SearchField();
                m_SearchField.downOrUpArrowKeyPressed += treeView.SetFocusAndEnsureSelectedItem;

                m_Initialized = true;
            }
        }

        IList<MyTreeElement> GetData()
        {
            if (m_MyTreeAsset != null && m_MyTreeAsset.treeElements != null && m_MyTreeAsset.treeElements.Count > 0)
            {
                return m_MyTreeAsset.treeElements;
            }

            // generate some test data
            return MyTreeElementGenerator.GenerateRandomTree(130);
        }

        void SearchBar(Rect rect)
        {
            treeView.searchString = m_SearchField.OnGUI(rect, treeView.searchString);
        }

        void DoTreeView(Rect rect)
        {
            treeView.OnGUI(rect);
        }

        void BottomToolBar(Rect rect)
        {
            GUILayout.BeginArea(rect);

            using (new EditorGUILayout.HorizontalScope())
            {
                var style = "miniButton";
                if (GUILayout.Button("Expand All", style))
                {
                    treeView.ExpandAll();
                }

                if (GUILayout.Button("Collapse All", style))
                {
                    treeView.CollapseAll();
                }

                GUILayout.FlexibleSpace();

                GUILayout.Label(m_MyTreeAsset != null ? AssetDatabase.GetAssetPath(m_MyTreeAsset) : string.Empty);

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Set sorting", style))
                {
                    var myColumnHeader = (MyMultiColumnHeader)treeView.multiColumnHeader;
                    myColumnHeader.SetSortingColumns(new[] { 4, 3, 2 }, new[] { true, false, true });
                    myColumnHeader.mode = MyMultiColumnHeader.Mode.LargeHeader;
                }

                GUILayout.Label("Header: ", "minilabel");
                if (GUILayout.Button("Large", style))
                {
                    var myColumnHeader = (MyMultiColumnHeader)treeView.multiColumnHeader;
                    myColumnHeader.mode = MyMultiColumnHeader.Mode.LargeHeader;
                }

                if (GUILayout.Button("Default", style))
                {
                    var myColumnHeader = (MyMultiColumnHeader)treeView.multiColumnHeader;
                    myColumnHeader.mode = MyMultiColumnHeader.Mode.DefaultHeader;
                }

                if (GUILayout.Button("No sort", style))
                {
                    var myColumnHeader = (MyMultiColumnHeader)treeView.multiColumnHeader;
                    myColumnHeader.mode = MyMultiColumnHeader.Mode.MinimumHeaderWithoutSorting;
                }

                GUILayout.Space(10);

                if (GUILayout.Button("values <-> controls", style))
                {
                    treeView.showControls = !treeView.showControls;
                }
            }

            GUILayout.EndArea();
        }
    }

    internal class MyMultiColumnHeader : MultiColumnHeader
    {
        public enum Mode
        {
            LargeHeader,
            DefaultHeader,
            MinimumHeaderWithoutSorting
        }

        Mode m_Mode;

        public MyMultiColumnHeader(MultiColumnHeaderState state)
            : base(state) =>
            mode = Mode.DefaultHeader;

        public Mode mode
        {
            get => m_Mode;
            set
            {
                m_Mode = value;
                switch (m_Mode)
                {
                    case Mode.LargeHeader:
                        canSort = true;
                        height = 37f;
                        break;
                    case Mode.DefaultHeader:
                        canSort = true;
                        height = DefaultGUI.defaultHeight;
                        break;
                    case Mode.MinimumHeaderWithoutSorting:
                        canSort = false;
                        height = DefaultGUI.minimumHeight;
                        break;
                }
            }
        }

        protected override void ColumnHeaderGUI(MultiColumnHeaderState.Column column, Rect headerRect, int columnIndex)
        {
            // Default column header gui
            base.ColumnHeaderGUI(column, headerRect, columnIndex);

            // Add additional info for large header
            if (mode == Mode.LargeHeader)
            {
                // Show example overlay stuff on some of the columns
                if (columnIndex > 2)
                {
                    headerRect.xMax -= 3f;
                    var oldAlignment = EditorStyles.largeLabel.alignment;
                    EditorStyles.largeLabel.alignment = TextAnchor.UpperRight;
                    GUI.Label(headerRect, 36 + columnIndex + "%", EditorStyles.largeLabel);
                    EditorStyles.largeLabel.alignment = oldAlignment;
                }
            }
        }
    }
}
