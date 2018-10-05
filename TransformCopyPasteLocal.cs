using UnityEngine;
using UnityEditor;

public static class TransformCopyPasteLocal
{
[Serializable]
    private class VectorArray
    {
        [SerializeField] internal Vector3 localPos;
        [SerializeField] internal Quaternion localRot;
        [SerializeField] internal Vector3 localScale;
        
        internal VectorArray(Transform tr)
        {
            if (!tr) return;
            localPos = tr.localPosition;
            localRot = tr.localRotation;
            localScale = tr.localScale;
        }
    }
    
    [MenuItem("CONTEXT/Transform/Copy local data")]
    private static void CopyLocalTr(MenuCommand cmd)
    {
        if (!cmd.context) return;
        
        Transform transform = (Transform)cmd.context;

        string data = JsonUtility.ToJson(new VectorArray(transform));

        EditorGUIUtility.systemCopyBuffer = data;

        Debug.Log("Copy local transform data to clipboard: " + EditorGUIUtility.systemCopyBuffer,transform);

    }

    [MenuItem("CONTEXT/Transform/Paste local data")]
    private static void PasteLocalTr(MenuCommand cmd)
    {
        if (!cmd.context) return;
        
        Transform transform = (Transform)cmd.context;

        var data = JsonUtility.FromJson<VectorArray>(EditorGUIUtility.systemCopyBuffer);

        Undo.RecordObject(transform,"paste local transform");
        
        transform.localPosition = data.localPos;
        transform.localRotation = data.localRot;
        transform.localScale= data.localScale;
        EditorUtility.SetDirty(transform);
        Debug.Log("Paste local transform data from clipboard: " + EditorGUIUtility.systemCopyBuffer,transform);
    }  
}
