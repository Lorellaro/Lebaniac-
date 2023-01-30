using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]//Scriptable object to reduce duplicated data.
public class StoryData : ScriptableObject
{
    [SerializeField] private List<BeatData> _beats;
 
    public BeatData GetBeatById( int id )
    {
        return _beats.Find(b => b.ID == id);
    }

#if UNITY_EDITOR
    public const string PathToAsset = "Assets/Data/Story.asset"; //Gets asset location

    public static StoryData LoadData()//When called returns storydata.asset
    {
        StoryData data = AssetDatabase.LoadAssetAtPath<StoryData>(PathToAsset);
        if (data == null)//if story.asset is null create an instance of storyData
        {
            data = CreateInstance<StoryData>();
            AssetDatabase.CreateAsset(data, PathToAsset);
        }

        return data;
    }
#endif
}

