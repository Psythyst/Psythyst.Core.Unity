using UnityEditor;
using UnityEditorInternal;

namespace Psythyst.Core.Unity.Editor
{
    [CustomEditor(typeof(ProjectUnitDefinition), true)]
    public class ProjectUnitDefinitionEditor : UnityEditor.Editor
    {
        private ReorderableList _GeneratorList;
        private ReorderableList _PostProcessorList;
        private ProjectUnitDefinition _ProjectUnitDefinition;

        private void OnEnable()
        {
            _GeneratorList = GetReordableList(true);
            _PostProcessorList = GetReordableList(false);

            _ProjectUnitDefinition = (ProjectUnitDefinition)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            /* Generator List. */
            EditorGUILayout.Space();
            _GeneratorList.DoLayoutList();

            /* PostProcessor List. */
            EditorGUILayout.Space();
            _PostProcessorList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }

        private ReorderableList GetReordableList(bool AsGenerator)
        {
            string Identifier = AsGenerator ? "Generator" : "PostProcessor";

            var _List = new ReorderableList(serializedObject, serializedObject.FindProperty($"{Identifier}DefinitionList"), true, true, true, true);

            _List.drawElementCallback = (UnityEngine.Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = _List.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;

                GeneratorDefinition _Generator = element.objectReferenceValue as System.Object as GeneratorDefinition;
                PostProcessorDefinition _PostProcessor = element.objectReferenceValue as System.Object as PostProcessorDefinition;

                if (_Generator != null)
                    _Generator.Enabled = EditorGUI.Toggle(new UnityEngine.Rect(rect.x, rect.y, 20, EditorGUIUtility.singleLineHeight),
                    _Generator.Enabled);
                else if (_PostProcessor != null)
                    _PostProcessor.Enabled = EditorGUI.Toggle(new UnityEngine.Rect(rect.x, rect.y, 20, EditorGUIUtility.singleLineHeight),
                    _PostProcessor.Enabled);

                EditorGUI.ObjectField(new UnityEngine.Rect(rect.x + 20, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight),
                    element, UnityEngine.GUIContent.none);
            };

            _List.drawHeaderCallback = (UnityEngine.Rect rect) =>
            {
                EditorGUI.LabelField(rect, $"{Identifier} Definition");


                EditorGUI.LabelField(new UnityEngine.Rect(rect.width - 90, rect.y, rect.width, EditorGUIUtility.singleLineHeight), "Override Order");

                if (AsGenerator)
                    _ProjectUnitDefinition.OverrideGeneratorOrder = EditorGUI.Toggle(new UnityEngine.Rect(rect.width + 6.45f, rect.y, 20, EditorGUIUtility.singleLineHeight),
                        _ProjectUnitDefinition.OverrideGeneratorOrder);
                else
                    _ProjectUnitDefinition.OverridePostProcessorOrder = EditorGUI.Toggle(new UnityEngine.Rect(rect.width + 6.45f, rect.y, 20, EditorGUIUtility.singleLineHeight),
                        _ProjectUnitDefinition.OverridePostProcessorOrder);
            };

            return _List;
        }
    }
}
