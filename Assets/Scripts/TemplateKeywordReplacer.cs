using UnityEngine;
using UnityEditor;
 
public class KeywordReplace : AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        if (index < 0)
            return;

        string file = path.Substring(index);
        if (file != ".cs")
            ChangeCSharpScript(ref path, out index);
    }

    private static void ChangeCSharpScript(ref string path, out int index)
    {
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;

        if (!System.IO.File.Exists(path))
            return;

        ChangeCsScriptContent(path);

        AssetDatabase.Refresh();
    }

    private static void ChangeCsScriptContent(string path)
    {
        string fileContent = System.IO.File.ReadAllText(path);

        fileContent = fileContent.Replace("#DATE#", System.DateTime.Now.ToString("u"));
        fileContent = fileContent.Replace("#FILE_EXT#", ".cs");
        DeveloperInformation information = AssetDatabase.LoadAssetAtPath<DeveloperInformation>("Assets/Editor/DeveloperInformation.asset");
        if (information)
        {
            fileContent = fileContent.Replace("#AUTHOR#", information.Name);
        }
        else
        {
            Debug.LogError("Failed to load DeveloperInformation");
        }

        System.IO.File.WriteAllText(path, fileContent);
    }
}
