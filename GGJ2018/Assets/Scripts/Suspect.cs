using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Suspect : MonoBehaviour {


    public string myLastName;
    public string myFirstName;

    public Text story;

    public static int personalityTraitCount = 3;
    public string[] pTraits = new string[personalityTraitCount];

    public string caseStory;

    // Use this for initialization
    void Start () {
        AssignPersonality();
	}


    void AssignPersonality()
    {
        int fNameIndex = Random.Range(0, AssetManager.firstNames.Count - 1);
        int lNameIndex = Random.Range(0, AssetManager.lastNames.Count - 1);

        myLastName = AssetManager.lastNames[lNameIndex];
        myFirstName = AssetManager.firstNames[fNameIndex];

        int[] reservedIndex = new int[personalityTraitCount]; 
        for(int i = 0; i < pTraits.Length; i++)
        {
            int pTraitIndex = Random.Range(0, AssetManager.personalityTraits.Count);
            for (int j = 0; j < personalityTraitCount; j++)
            {
                while(pTraitIndex == reservedIndex[j])
                {
                    pTraitIndex = Random.Range(0, AssetManager.personalityTraits.Count);
                }
            }
            pTraits[i] = AssetManager.personalityTraits[pTraitIndex];
            reservedIndex[i] = pTraitIndex;
        }

        BuildStory();

    }

    void BuildStory()
    {
        string baseStory = AssetManager.storyBases[Random.Range(0, AssetManager.storyBases.Count)];
        string fixedStory = null; 
        while(fixedStory == null)
        {
            fixedStory = baseStory
            .Replace("!dAdj!", AssetManager.denominalAdjectives[Random.Range(0, AssetManager.denominalAdjectives.Count - 1)])
            .Replace("!fAdj!", AssetManager.formingAdjectives[Random.Range(0, AssetManager.formingAdjectives.Count - 1)])
            .Replace("!firstname!", myFirstName)
            .Replace("!lastname!", myLastName)
            .Replace("!obj!", AssetManager.objects[Random.Range(0, AssetManager.objects.Count - 1)])
            .Replace("!goodverb!", AssetManager.goodVerbs[Random.Range(0, AssetManager.goodVerbs.Count - 1)])
            .Replace("!badverb!", AssetManager.badVerbs[Random.Range(0, AssetManager.badVerbs.Count - 1)]);
        }


        story.text = fixedStory;

    }
	// Update is called once per frame
	void Update () {


		
	}
}
