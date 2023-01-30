using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BeatData
{
    //Initialisation
    [SerializeField] private List<ChoiceData> _choices;
    [SerializeField] private string _text;
    [SerializeField] private int _id;

    //Allows variables above to be obtained in other classes
    public List<ChoiceData> Decision { get { return _choices; } } //When decision is called elsewhere then it will return the _choices list
    public string DisplayText { get { return _text; } }
    public int ID { get { return _id; } }
}
