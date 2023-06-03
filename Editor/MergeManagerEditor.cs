using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(MergeManager))]
public class MergeManagerEditor : Editor
{
    private MergeManager _mergeManager;


    public void OnEnable()
    {
        _mergeManager = (MergeManager)target;
    }

    public override void OnInspectorGUI()
    {
        if (_mergeManager.mergeMelee.Count > 0)
        {
            foreach (MergeMelee melee in _mergeManager.mergeMelee)
            {
                EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    _mergeManager.mergeMelee.Remove(melee);
                    break;
                }
                melee.mergeID = EditorGUILayout.IntField("Уровень", melee.mergeID);
                melee.damage = EditorGUILayout.FloatField("Урон", melee.damage);
                melee.health = EditorGUILayout.IntField("Здоровье", melee.health);
                melee.meleeType = (MeleeType)EditorGUILayout.EnumPopup("Тип милишника", melee.meleeType);
                melee.characterPrefab = (GameObject)EditorGUILayout.ObjectField("Преваб тела", melee.characterPrefab, typeof(GameObject), false);

                EditorGUILayout.EndVertical();
            }
        }
        else EditorGUILayout.LabelField("Нет милишников");

        if (GUILayout.Button("Добавить новый уровень милишника", GUILayout.Height(30))) _mergeManager.mergeMelee.Add(new MergeMelee());

        if (_mergeManager.mergeRange.Count > 0)
        {
            foreach (MergeRange range in _mergeManager.mergeRange)
            {
                EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    _mergeManager.mergeRange.Remove(range);
                    break;
                }
                range.mergeID = EditorGUILayout.IntField("Уровень", range.mergeID);
                range.damage = EditorGUILayout.FloatField("Урон", range.damage);
                range.health = EditorGUILayout.IntField("Здоровье", range.health);
                range.characterPrefab = (GameObject)EditorGUILayout.ObjectField("Преваб тела", range.characterPrefab, typeof(GameObject), false);
                range.arrowPrefab = (GameObject)EditorGUILayout.ObjectField("Преваб стрелы", range.arrowPrefab, typeof(GameObject), false);
    
                EditorGUILayout.EndVertical();
            }
        }
        else EditorGUILayout.LabelField("Нет дальников");

        if (GUILayout.Button("Добавить новый уровень дальника", GUILayout.Height(30))) _mergeManager.mergeRange.Add(new MergeRange());

        if (GUI.changed) SetObjectDirty(_mergeManager.gameObject);
    }

    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
}
