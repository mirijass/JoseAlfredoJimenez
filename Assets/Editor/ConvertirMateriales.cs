using UnityEngine;
using UnityEditor;

public class ConvertirMateriales : EditorWindow
{
    [MenuItem("Tools/Corregir materiales del modelo")]
    public static void CorregirMateriales()
    {
        Object[] seleccionados = Selection.objects;

        Shader standardShader = Shader.Find("Standard");

        if (standardShader == null)
        {
            Debug.LogError("No se encontró el shader Standard.");
            return;
        }

        int corregidos = 0;

        foreach (Object obj in seleccionados)
        {
            Material mat = obj as Material;

            if (mat == null)
                continue;

            // Guardar el color que ya tiene el material
            Color colorOriginal = Color.white;

            if (mat.HasProperty("_BaseColor"))
            {
                colorOriginal = mat.GetColor("_BaseColor");
            }
            else if (mat.HasProperty("_Color"))
            {
                colorOriginal = mat.GetColor("_Color");
            }

            Undo.RecordObject(mat, "Corregir Material");

            // Cambiar a Standard de Unity
            mat.shader = standardShader;

            // Recuperar el color
            mat.SetColor("_Color", colorOriginal);

            // Valores recomendados
            mat.SetFloat("_Metallic", 0f);
            mat.SetFloat("_Glossiness", 0.25f);

            EditorUtility.SetDirty(mat);

            corregidos++;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Materiales corregidos: " + corregidos);
    }
}