using UnityEngine;
using System.Collections;


namespace wuxingogo.Runtime
{

	public class XScriptableObject : ScriptableObject
	{
        public virtual void OnCtor()
        {

        }

		public bool hasFile = false;

        public static T Create<T>(Object parent) where T : XScriptableObject
        {
            T asset = XScriptableObject.CreateInstance<T>();
            asset.OnCtor();
			if (parent != null) {
				asset.hasFile = true;
				wuxingogo.Reflection.XReflectionUtils.AddObjectToObject (asset, parent);
			}

            return asset;
        }

		public static XScriptableObject Create( System.Type objectType, Object parent)
        {
            XScriptableObject asset = XScriptableObject.CreateInstance( objectType ) as XScriptableObject;
            asset.OnCtor();
			if (parent != null) {
				asset.hasFile = true;
				wuxingogo.Reflection.XReflectionUtils.AddObjectToObject (asset, parent);
			}
            return asset;
        }
		public void SaveInEditor()
		{
			wuxingogo.Reflection.XReflectionUtils.Save (this);
		}

    }
}
