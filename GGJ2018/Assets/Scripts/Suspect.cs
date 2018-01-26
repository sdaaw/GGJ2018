﻿using System;
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

    public int badVerbCount = 0;
    public int goodVerbCount = 0;

    [SerializeField]
    private SpriteRenderer m_torso;
    [SerializeField]
    private SpriteRenderer m_hair;
    [SerializeField]
    private SpriteRenderer m_eyebrows;
    [SerializeField]
    private SpriteRenderer m_eyes;
    [SerializeField]
    private SpriteRenderer m_moustache;
    [SerializeField]
    private SpriteRenderer m_mouth;

    public void SetSprites(Sprite torso, Sprite hair, Sprite eyebrows, Sprite eyes, Sprite moustache, Sprite mouth)
    {
        m_torso.sprite = torso;
        m_hair.sprite = hair;
        m_eyebrows.sprite = eyebrows;
        m_eyes.sprite = eyes;
        m_moustache.sprite = moustache;
        m_mouth.sprite = mouth;     
    }

    public void SetSpriteColors(Color skinC, Color torsoC, Color hairC, Color eyebrowsC, Color eyesC, Color moustacheC, Color mouthC)
    {
        m_torso.color = skinC;
        //skin
        m_hair.color = hairC;
        m_eyebrows.color = eyebrowsC;
        //m_eyes.color = eyesC;
        m_moustache.color = moustacheC;
        m_mouth.color = mouthC;
    }

    public Color getRndColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }


    // Use this for initialization
    void Start () {
        AssignPersonality();
	}


    public void AssignPersonality()
    {
        int fNameIndex = UnityEngine.Random.Range(0, AssetManager.firstNames.Count - 1);
        int lNameIndex = UnityEngine.Random.Range(0, AssetManager.lastNames.Count - 1);

        myLastName = AssetManager.lastNames[lNameIndex];
        myFirstName = AssetManager.firstNames[fNameIndex];

        int[] reservedIndex = new int[personalityTraitCount]; 
        for(int i = 0; i < pTraits.Length; i++)
        {
            int pTraitIndex = UnityEngine.Random.Range(0, AssetManager.personalityTraits.Count);
            for (int j = 0; j < personalityTraitCount; j++)
            {
                while(pTraitIndex == reservedIndex[j])
                {
                    pTraitIndex = UnityEngine.Random.Range(0, AssetManager.personalityTraits.Count);
                }
            }
            pTraits[i] = AssetManager.personalityTraits[pTraitIndex];
            reservedIndex[i] = pTraitIndex;
        }

        BuildStory();

    }

    void BuildStory()
    {
        string baseStory = AssetManager.storyBases[UnityEngine.Random.Range(0, AssetManager.storyBases.Count - 1)];
        string fixedStory = null; 
        while(fixedStory == null)
        {
            fixedStory = baseStory
            .Replace("!dAdj!", AssetManager.denominalAdjectives[UnityEngine.Random.Range(0, AssetManager.denominalAdjectives.Count - 1)])
            .Replace("!fAdj!", AssetManager.formingAdjectives[UnityEngine.Random.Range(0, AssetManager.formingAdjectives.Count - 1)])
            .Replace("!firstname!", myFirstName)
            .Replace("!lastname!", myLastName)
            .Replace("!obj!", AssetManager.objects[UnityEngine.Random.Range(0, AssetManager.objects.Count - 1)])
            .Replace("!goodverb!", AssetManager.goodVerbs[UnityEngine.Random.Range(0, AssetManager.goodVerbs.Count - 1)])
            .Replace("!badverb!", AssetManager.badVerbs[UnityEngine.Random.Range(0, AssetManager.badVerbs.Count - 1)]);
        }

        string badVerbs = "!badverb!";
        string input = baseStory;
        string[] arr = input.Split(new char[] { ' ', '.' });
        int count = Array.FindAll(arr, s => s.Equals(badVerbs.Trim())).Length;
        badVerbCount = count;
        count = 0;
        string goodVerbs = "!goodverb!";
        input = baseStory;
        arr = input.Split(new char[] { ' ', '.' });
        count = Array.FindAll(arr, s => s.Equals(goodVerbs.Trim())).Length;
        goodVerbCount = count;


        story.text = fixedStory;

    }
	// Update is called once per frame
	void Update () {


		
	}
}
