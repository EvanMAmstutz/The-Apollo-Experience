using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RandomDistributionScript))]
public class RandomDistributionScriptEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		EditorGUIUtility.wideMode = true;
	
		serializedObject.Update();
		SerializedProperty pool = serializedObject.FindProperty("pool");
		SerializedProperty poolWeights = serializedObject.FindProperty("poolWeight");
		
		EditorGUILayout.PropertyField(pool);
		pool.Next(true);
		pool.Next(true);
		poolWeights.Next(true);
		poolWeights.Next(true);
		int poolsize = pool.intValue;
		EditorGUILayout.PropertyField(pool);
		for(int i = 0; i < poolsize; i++)
		{
			pool.Next(false);
			poolWeights.Next(false);
			EditorGUILayout.PropertyField(pool, new GUIContent("Prefab " + i));
			EditorGUILayout.Slider(poolWeights, 0f, 1f, "Weight " + i);
		}
		
		EditorGUILayout.Space();
		SerializedProperty sp = serializedObject.FindProperty("amount");
		do
		{
			EditorGUILayout.PropertyField(sp);
			
			if(sp.name == "maskType")
			{
				if(sp.enumValueIndex == (int)RandomDistributionScript.MaskType.None)
				{
					while(sp.Next(false)){if(sp.name == "maskThreshold") break;}
				}
			}
			
			if(sp.name == "colorType")
			{
				if(sp.enumValueIndex == (int)RandomDistributionScript.EditType.None)
				{
					while(sp.Next(false)){if(sp.name == "colorMin") break;}
				}
				else if(sp.enumValueIndex == (int)RandomDistributionScript.EditType.Rndom)
				{
					sp.Next(false);
				}
			}
			
			if(sp.name == "scaleType")
			{
				if(sp.enumValueIndex == (int)RandomDistributionScript.EditType.None)
				{				
					while(sp.Next(false)){if(sp.name == "scaleMin") break;}
				}
				else if(sp.enumValueIndex == (int)RandomDistributionScript.EditType.Rndom)
				{
					sp.Next(false);
				}
			}
			
			if(sp.name == "rotationType")
			{
				if(sp.enumValueIndex == (int)RandomDistributionScript.RotationType.None)
				{				
					while(sp.Next(false)){if(sp.name == "rotationDeltaZ") break;}
				}
			}
			
			if(sp.name == "scaleMin" || sp.name == "colorMin" || sp.name == "maskThreshold" || sp.name == "seed" || sp.name ==  "projectToSurface" || sp.name ==  "inverted" ||  sp.name == "combineMeshes")
			{
				EditorGUILayout.Space();
			}
		}
		while(sp.Next(false) == true);	
			
		serializedObject.ApplyModifiedProperties();
	}
}
