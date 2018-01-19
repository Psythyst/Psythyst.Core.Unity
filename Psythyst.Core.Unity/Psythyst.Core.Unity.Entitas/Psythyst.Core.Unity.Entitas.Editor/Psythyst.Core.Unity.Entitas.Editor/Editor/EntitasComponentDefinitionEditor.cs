using UnityEditor;
using UnityEditorInternal;

namespace Psythyst.Core.Unity.Entitas.Editor
{
    [CustomEditor(typeof(EntitasComponentDefinition))]
    public class EntitasComponentDefinitionDrawer : UnityEditor.Editor
    {
        private ReorderableList _ContextList;
        private ReorderableList _AttributeList;

        private EntitasComponentDefinition _ComponentDefinition;

        private void OnEnable()
        {
            _ContextList = GetContextReordableList();
            _AttributeList = GetAttributeReordableList();

            _ComponentDefinition = (EntitasComponentDefinition)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _ComponentDefinition.ComponentName = EditorGUILayout.TextField("Component Name", _ComponentDefinition.ComponentName);
            _ComponentDefinition.Unique = EditorGUILayout.Toggle("Unique", _ComponentDefinition.Unique);
            _ComponentDefinition.UniquePrefix = EditorGUILayout.TextField("Unique Prefix", _ComponentDefinition.UniquePrefix);

            /* Context List. */
            EditorGUILayout.Space();
            _ContextList.DoLayoutList();

            /* Attribute List. */
            EditorGUILayout.Space();
            _AttributeList.DoLayoutList();

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

        private ReorderableList GetAttributeReordableList()
        {
            var _List = new ReorderableList(serializedObject, serializedObject.FindProperty("MemberDefinitionList"), true, true, true, true);

            /* Draw Element Callback. */
            _List.drawElementCallback = (UnityEngine.Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = _List.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;

                float Division = 2.755f;

                var TypeLabelRect = new UnityEngine.Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
                var TypeRect = new UnityEngine.Rect(rect.x + 40, rect.y, (rect.width / Division) - 40, EditorGUIUtility.singleLineHeight);

                var NameLabelRect = new UnityEngine.Rect((rect.width / Division) + 40, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
                var NameRect = new UnityEngine.Rect((rect.width / Division) + 80, rect.y, (rect.width / Division) - 50, EditorGUIUtility.singleLineHeight);

                var IndexLabelRect = new UnityEngine.Rect((rect.width / Division) * 2 + 40, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
                var IndexRect = new UnityEngine.Rect((rect.width / Division) * 2 + 80, rect.y, rect.width - ((rect.width / Division) * 2 + 45), EditorGUIUtility.singleLineHeight);


                EditorGUI.LabelField(TypeLabelRect, "Type");
                EditorGUI.PropertyField(TypeRect, element.FindPropertyRelative("Type"), UnityEngine.GUIContent.none);

                EditorGUI.LabelField(NameLabelRect, "Name");
                EditorGUI.PropertyField(NameRect, element.FindPropertyRelative("Name"), UnityEngine.GUIContent.none);

                EditorGUI.LabelField(IndexLabelRect, "Index");
                EditorGUI.PropertyField(IndexRect, element.FindPropertyRelative("Index"), UnityEngine.GUIContent.none);
            };

            /* Element Addded Callback. */
            _List.onAddCallback = (ReorderableList List) => 
            {
                var Index = List.serializedProperty.arraySize;
                List.serializedProperty.arraySize++;
                List.index = Index;
                var Element = List.serializedProperty.GetArrayElementAtIndex(Index);

                /* Constant As Default. */
                Element.FindPropertyRelative("Type")
                       .FindPropertyRelative("UseConstant").boolValue = true;
                Element.FindPropertyRelative("Name")
                       .FindPropertyRelative("UseConstant").boolValue = true;
            };

            _List.drawHeaderCallback = (UnityEngine.Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Member Definition");
            };

            return _List;
        }
    }
}
