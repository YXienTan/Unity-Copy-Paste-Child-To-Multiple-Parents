using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Unity Editor Window script to copy and paste child objects to multiple selected parent objects.
/// </summary>
public class PasteChildToMultipleParents : EditorWindow
{
    // Stores the list of copied child objects
    private static List<GameObject> copiedObjects = new List<GameObject>();

    /// <summary>
    /// Shows the Paste Child to Selected Parents window in the Unity Editor.
    /// </summary>
    [MenuItem("Tools/Paste Child To Selected Parents")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PasteChildToMultipleParents));
    }

    // Main GUI of the Editor Window
    void OnGUI()
    {
        GUILayout.Label("Paste Child To Multiple Parents", EditorStyles.boldLabel);

        // Button to copy the selected child objects
        if (GUILayout.Button("Copy Child"))
        {
            CopySelectedObjects();
        }

        // Display the copied child objects
        if (copiedObjects.Count > 0)
        {
            GUILayout.Label("Copied Child/Children:");
            for (int i = copiedObjects.Count - 1; i >= 0; i--)
            {
                // Check if the copied object still exists
                if (copiedObjects[i] == null)
                {
                    copiedObjects.RemoveAt(i); // Remove if deleted
                }
                else
                {
                    EditorGUILayout.ObjectField(copiedObjects[i].name, copiedObjects[i], typeof(GameObject), false);
                }
            }
        }
        else
        {
            GUILayout.Label("No object copied. Use 'Copy Child' to copy one or more objects.");
        }

        // Button to paste the copied child objects to the selected parent objects
        if (GUILayout.Button("Paste Child"))
        {
            PasteCopiedObjectsToSelectedParents();
        }
    }

    /// <summary>
    /// Copies the currently selected objects in the hierarchy.
    /// </summary>
    private void CopySelectedObjects()
    {
        // Record the action for Undo functionality
        Undo.RecordObject(this, "Copy Child Objects");
        copiedObjects.Clear(); // Clear any previously copied objects
        if (Selection.objects.Length > 0)
        {
            // Add selected GameObjects to the copied objects list
            foreach (var obj in Selection.objects)
            {
                if (obj is GameObject go)
                {
                    copiedObjects.Add(go);
                }
            }
            Debug.Log("Copied " + copiedObjects.Count + " object(s).");
        }
        else
        {
            Debug.LogWarning("No object selected to copy.");
        }
    }

    /// <summary>
    /// Pastes the copied child objects under the selected parent objects in the hierarchy.
    /// </summary>
    private void PasteCopiedObjectsToSelectedParents()
    {
        if (copiedObjects.Count > 0)
        {
            // Group the paste action for Undo functionality
            Undo.IncrementCurrentGroup();
            foreach (var selectedParent in Selection.gameObjects)
            {
                foreach (var copiedObject in copiedObjects)
                {
                    if (copiedObject != null)
                    {
                        GameObject newChild;
                        // Check if the copied object is a Prefab
                        if (PrefabUtility.IsPartOfPrefabAsset(copiedObject))
                        {
                            // Paste as a Prefab instance
                            newChild = (GameObject)PrefabUtility.InstantiatePrefab(copiedObject, selectedParent.transform);
                        }
                        else
                        {
                            // Paste as a regular GameObject
                            newChild = Instantiate(copiedObject, selectedParent.transform);
                        }

                        newChild.name = copiedObject.name;
                        Undo.RegisterCreatedObjectUndo(newChild, "Paste Child"); // Register for Undo
                    }
                }
            }
            Debug.Log("Pasted " + copiedObjects.Count + " object(s) to " + Selection.gameObjects.Length + " parent(s).");
        }
        else
        {
            Debug.LogWarning("No object copied to paste.");
        }
    }

    /// <summary>
    /// Clears the copied objects when the window is closed.
    /// </summary>
    void OnDisable()
    {
        copiedObjects.Clear();
        Debug.Log("Window closed, copied objects cleared.");
    }
}