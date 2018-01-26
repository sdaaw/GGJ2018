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
    public static List<string> storyBases = new List<string>();
    public static List<string> goodVerbs = new List<string>();
    public static List<string> badVerbs = new List<string>();
    public static List<string> objects = new List<string>();

    string firstNamePath = @"SharedAssets/firstNameList.txt";
    string lastNamePath = @"SharedAssets/lastNameList.txt";
    string personalityPath = @"SharedAssets/personalityTraits.txt";
    string formingAdjectivePath = @"SharedAssets/formingAdjectiveList.txt";
    string denominalAdjectivePath = @"SharedAssets/denominalAdjectiveList.txt";
    string storyPath = @"SharedAssets/storyBases.txt";
    string goodVerbPath = @"SharedAssets/goodVerbList.txt";
    string badVerbPath = @"SharedAssets/badVerbList.txt";
    string objectPath = @"SharedAssets/objectList.txt";

    // Use this for initialization
    void Start () {
        LoadAssets();
	}
	
	// Update is called once per frame
	void Update () {
		
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


        reader = new StreamReader(storyPath);
        text = reader.ReadToEnd();
        names = text.Split(';');
        foreach (string name in names)
        {
            storyBases.Add(name);
        }

        reader.Close();
    }
}
