
namespace wuxingogo.Attribute
{
    using UnityEngine;
    using UnityEditor;
    using wuxingogo.Runtime;

    [CustomPropertyDrawer(typeof(DisableAttribute), true)]
    public class DisableDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var disableAttr = base.attribute as DisableAttribute;

            if (disableAttr.IsEditInEditor && !EditorApplication.isPlaying)
            {
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.EndDisabledGroup();
            }
        }

    }
}
