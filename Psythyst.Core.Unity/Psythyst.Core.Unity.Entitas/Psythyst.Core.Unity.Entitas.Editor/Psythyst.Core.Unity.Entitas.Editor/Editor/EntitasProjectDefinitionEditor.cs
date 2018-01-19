using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Psythyst.Core.Unity.Entitas.Editor
{
    [CustomEditor(typeof(EntitasProjectDefinition))]
    public class EntitasProjectDefinitionDrawer : UnityEditor.Editor
    {
        private ReorderableList _ContextList;
        private ReorderableList _ComponentList;
        private EntitasProjectDefinition _ProjectDefinition;

        private void OnEnable()
        {
            _ContextList = GetContextReordableList();
            _ComponentList = GetComponentReordableList();

            _ProjectDefinition = (EntitasProjectDefinition)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            /* Project Unit Definition. */
            EditorGUILayout.ObjectField(serializedObject.FindProperty("ProjectUnitDefinition"));

            if (GUILayout.Button("Generate"))
            {
                _ProjectDefinition.Generate();
            }


            /* Context List. */
            EditorGUILayout.Space();
            _ContextList.DoLayoutList();

            /* Component List. */
            EditorGUILayout.Space();
            _ComponentList.DoLayoutList();


            serializedObject.ApplyModifiedProperties();
        }


        private ReorderableList GetContextReordableList()
        {
            var _List = new ReorderableList(serializedObject, serializedObject.FindProperty("ContextDefinitionList"), true, true, true, true);

            _List.drawElementCallback = (UnityEngine.Rect rect, int index, bool isActive, bool isFocused) =>
            {

                var element = _List.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;

                EditorGUI.ObjectField(new UnityEngine.Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    element, UnityEngine.GUIContent.none);
            };

            _List.drawHeaderCallback = (UnityEngine.Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Context Definition");
            };

            return _List;
        }

        private ReorderableList GetComponentReordableList()
        {
            var _List = new ReorderableList(serializedObject, serializedObject.FindProperty("ComponentDefinitionList"), true, true, true, true);

            _List.drawElementCallback = (UnityEngine.Rect rect, int index, bool isActive, bool isFocused) =>
            {

                var element = _List.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;

                EditorGUI.ObjectField(new UnityEngine.Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    element, UnityEngine.GUIContent.none);
            };

            _List.drawHeaderCallback = (UnityEngine.Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Component Definition");
            };

            return _List;
        }
    }
}
