using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Suspect : MonoBehaviour {

    public List<string> firstNames = new List<string>();
    public List<string> lastNames = new List<string>();
    public List<string> personalityTraits = new List<string>();
    public List<string> formingAdjectives = new List<string>();
    public List<string> denominalAdjectives = new List<string>();
    public List<string> storyBases = new List<string>();
    public List<string> goodVerbs = new List<string>();
    public List<string> badVerbs = new List<string>();
    public List<string> objects = new List<string>();

    public Text story;

    string firstNamePath = @"SharedAssets/firstNameList.txt";
    string lastNamePath = @"SharedAssets/lastNameList.txt";
    string personalityPath = @"SharedAssets/personalityTraits.txt";
    string formingAdjectivePath = @"SharedAssets/formingAdjectiveList.txt";
    string denominalAdjectivePath = @"SharedAssets/denominalAdjectiveList.txt";
    string storyPath = @"SharedAssets/storyBases.txt";
    string goodVerbPath = @"SharedAssets/goodVerbList.txt";
    string badVerbPath = @"SharedAssets/badVerbList.txt";
    string objectPath = @"SharedAssets/objectList.txt";


    public string myLastName;
    public string myFirstName;

    public static int personalityTraitCount = 3;
    public string[] pTraits = new string[personalityTraitCount];

    public string caseStory;

    // Use this for initialization
    void Start () {
        LoadAssets();
        AssignPersonality();
	}


    void AssignPersonality()
    {
        int fNameIndex = Random.Range(0, firstNames.Count);
        int lNameIndex = Random.Range(0, lastNames.Count);

        myLastName = lastNames[lNameIndex];
        myFirstName = firstNames[fNameIndex];

        int[] reservedIndex = new int[personalityTraitCount]; 
        for(int i = 0; i < pTraits.Length; i++)
        {
            int pTraitIndex = Random.Range(0, personalityTraits.Count);
            for (int j = 0; j < personalityTraitCount; j++)
            {
                while(pTraitIndex == reservedIndex[j])
                {
                    pTraitIndex = Random.Range(0, personalityTraits.Count);
                }
            }
            pTraits[i] = personalityTraits[pTraitIndex];
            reservedIndex[i] = pTraitIndex;
        }

        BuildStory();

    }

    void BuildStory()
    {
        string baseStory = storyBases[Random.Range(0, storyBases.Count)];
        string fixedStory = null; 
        while(fixedStory == null)
        {
            fixedStory = baseStory
            .Replace("!dAdj!", denominalAdjectives[Random.Range(0, denominalAdjectives.Count)])
            .Replace("!fAdj!", formingAdjectives[Random.Range(0, formingAdjectives.Count)])
            .Replace("!firstname!", myFirstName)
            .Replace("!lastname!", myLastName)
            .Replace("!obj!", objects[Random.Range(0, objects.Count)])
            .Replace("!goodverb!", goodVerbs[Random.Range(0, goodVerbs.Count)])
            .Replace("!badverb!", badVerbs[Random.Range(0, badVerbs.Count)]);
        }


        story.text = fixedStory;

    }

    void LoadAssets()
    {
        int lineCount = 0;
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
        //Debug.Log("First names loaded: " + firstNames.Count + " | Last names loaded: " + lastNames.Count);
    }
	// Update is called once per frame
	void Update () {


		
	}
}
