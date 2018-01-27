using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetManager : MonoBehaviour {

    public static List<string> firstNames = new List<string>();
    public static List<string> lastNames = new List<string>();
    public static List<string> personalityTraits = new List<string>();
    public static List<string> formingAdjectives = new List<string>();
    public static List<string> denominalAdjectives = new List<string>();
    public static List<string> story1Bases = new List<string>();
    public static List<string> story2Bases = new List<string>();
    public static List<string> story3Bases = new List<string>();
    public static List<string> story4Bases = new List<string>();
    public static List<string> story5Bases = new List<string>();
    public static List<string> goodVerbs = new List<string>();
    public static List<string> badVerbs = new List<string>();
    public static List<string> objects = new List<string>();

    string firstNamePath = @"SharedAssets/firstNameList.txt";
    string lastNamePath = @"SharedAssets/lastNameList.txt";
    string personalityPath = @"SharedAssets/personalityTraits.txt";
    string formingAdjectivePath = @"SharedAssets/formingAdjectiveList.txt";
    string denominalAdjectivePath = @"SharedAssets/denominalAdjectiveList.txt";
    string story1Path = @"SharedAssets/level1Story.txt";
    string story2Path = @"SharedAssets/level2Story.txt";
    string story3Path = @"SharedAssets/level3Story.txt";
    string story4Path = @"SharedAssets/level4Story.txt";
    string story5Path = @"SharedAssets/level5Story.txt";
    string goodVerbPath = @"SharedAssets/goodVerbList.txt";
    string badVerbPath = @"SharedAssets/badVerbList.txt";
    string objectPath = @"SharedAssets/objectList.txt";

    // Use this for initialization
    void Awake () {
        LoadAssets();
	}


    void LoadAssets()
    {
        StreamReader reader = new StreamReader(firstNamePath);
        string text = reader.ReadToEnd();
        string[] names = text.Split(',');
        foreach (string name in names)
        {
            firstNames.Add(name);
        }
        reader = new StreamReader(lastNamePath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            lastNames.Add(name);
        }

        reader = new StreamReader(personalityPath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            personalityTraits.Add(name);
        }

        reader = new StreamReader(denominalAdjectivePath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            denominalAdjectives.Add(name);
        }
        reader = new StreamReader(formingAdjectivePath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            formingAdjectives.Add(name);
        }
        reader = new StreamReader(goodVerbPath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            goodVerbs.Add(name);
        }
        reader = new StreamReader(badVerbPath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            badVerbs.Add(name);
        }
        reader = new StreamReader(objectPath);
        text = reader.ReadToEnd();
        names = text.Split(',');
        foreach (string name in names)
        {
            objects.Add(name);
        }


        reader = new StreamReader(story1Path);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            story1Bases.Add(name);
        }
        reader = new StreamReader(story2Path);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            story2Bases.Add(name);
        }
        reader = new StreamReader(story3Path);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            story3Bases.Add(name);
        }
        reader = new StreamReader(story4Path);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            story4Bases.Add(name);
        }
        reader = new StreamReader(story5Path);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            story5Bases.Add(name);
        }

        reader.Close();
    }
}
