using System;
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

    public string myProfession = null;

    private int storyLevel;

    [SerializeField]
    private Text m_nameText;
    [SerializeField]
    private Text m_careerText;

    [SerializeField]
    private SpriteRenderer m_head;
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

    [SerializeField]
    private Image m_headSImg;
    [SerializeField]
    private Image m_hairSImg;
    [SerializeField]
    private Image m_eyebrowsSImg;
    [SerializeField]
    private Image m_eyesSImg;
    [SerializeField]
    private Image m_moustacheSImg;
    [SerializeField]
    private Image m_mouthSImg;

    public Animator particle;

    public void SetSprites(Sprite head, Sprite torso, Sprite hair, Sprite eyebrows, Sprite eyes, Sprite moustache, Sprite mouth)
    {
        m_head.sprite = head;
        m_torso.sprite = torso;
        m_hair.sprite = hair;
        m_eyebrows.sprite = eyebrows;
        m_eyes.sprite = eyes;
        m_moustache.sprite = moustache;
        m_mouth.sprite = mouth;

        m_headSImg.sprite = head;
        m_hairSImg.sprite = hair;
        m_eyebrowsSImg.sprite = eyebrows;
        m_eyesSImg.sprite = eyes;
        m_moustacheSImg.sprite = moustache;
        m_mouthSImg.sprite = mouth;
    }

    public void SetSpriteColors(Color skinC, Color torsoC, Color hairC, Color eyebrowsC, Color eyesC, Color moustacheC, Color mouthC)
    {
        m_head.color = skinC;
        m_torso.color = torsoC;
        m_hair.color = hairC;
        m_eyebrows.color = eyebrowsC;
        //m_eyes.color = eyesC;
        m_moustache.color = moustacheC;
        m_mouth.color = mouthC;

        m_headSImg.color = skinC;
        m_hairSImg.color = hairC;
        m_eyebrowsSImg.color = eyebrowsC;
        //m_eyesSImg.color = eyes;
        if (m_moustache.sprite != null)
            m_moustacheSImg.color = moustacheC;
        else
            m_moustacheSImg.color = Color.clear;
        m_mouthSImg.color = mouthC;
    }

    public Color getRndColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }


    // Use this for initialization
    void Start () {
        AssignPersonality();
        StartCoroutine("FlipEyes");
	}


    public void AssignPersonality()
    {
        int fNameIndex = UnityEngine.Random.Range(0, AssetManager.firstNames.Count - 1);
        int lNameIndex = UnityEngine.Random.Range(0, AssetManager.lastNames.Count - 1);

        myLastName = AssetManager.lastNames[lNameIndex];
        myFirstName = AssetManager.firstNames[fNameIndex];

        myProfession = AssetManager.profession[(UnityEngine.Random.Range(0, AssetManager.profession.Count - 1))];

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

        m_nameText.text = myFirstName + " " + myLastName;
        m_careerText.text = myProfession;

        BuildStory();

    }

    private IEnumerator FlipEyes()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
        m_eyes.flipX = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
        m_eyes.flipX = false;
        StartCoroutine("FlipEyes");
    }

    void BuildStory()
    {
        goodVerbCount = 0;
        badVerbCount = 0;
        string baseStory = null;
        if(GameManager.caseStoryLevel == 1) baseStory = AssetManager.story1Bases[UnityEngine.Random.Range(0, AssetManager.story1Bases.Count - 1)];
        if(GameManager.caseStoryLevel == 2) baseStory = AssetManager.story2Bases[UnityEngine.Random.Range(0, AssetManager.story2Bases.Count - 1)];
        if(GameManager.caseStoryLevel == 3) baseStory = AssetManager.story3Bases[UnityEngine.Random.Range(0, AssetManager.story3Bases.Count - 1)];
        if(GameManager.caseStoryLevel == 4) baseStory = AssetManager.story4Bases[UnityEngine.Random.Range(0, AssetManager.story4Bases.Count - 1)];
        if(GameManager.caseStoryLevel == 5) baseStory = AssetManager.story5Bases[UnityEngine.Random.Range(0, AssetManager.story5Bases.Count - 1)];



        string fixedStory = null;

        //replaceboys
        fixedStory = baseStory
        .Replace("!dAdj!", AssetManager.denominalAdjectives[UnityEngine.Random.Range(0, AssetManager.denominalAdjectives.Count - 1)])
        .Replace("!fAdj!", AssetManager.formingAdjectives[UnityEngine.Random.Range(0, AssetManager.formingAdjectives.Count - 1)])
        .Replace("!firstname!", myFirstName)
        .Replace("!lastname!", myLastName)
        .Replace("!obj!", AssetManager.objects[UnityEngine.Random.Range(0, AssetManager.objects.Count - 1)])
        .Replace("!goodverb!", AssetManager.goodVerbs[UnityEngine.Random.Range(0, AssetManager.goodVerbs.Count - 1)])
        .Replace("!badverb!", AssetManager.badVerbs[UnityEngine.Random.Range(0, AssetManager.badVerbs.Count - 1)])
        .Replace("!goodverb2!", AssetManager.goodVerbs2[UnityEngine.Random.Range(0, AssetManager.goodVerbs2.Count - 1)])
        .Replace("!badverb2!", AssetManager.badVerbs2[UnityEngine.Random.Range(0, AssetManager.badVerbs2.Count - 1)]);

        string badVerbs = "!badverb!";
        string input = baseStory;
        string[] arr = input.Split(new char[] { ' ', '.' , '<', '>'});
        int count = Array.FindAll(arr, s => s.Equals(badVerbs.Trim())).Length;
        badVerbCount += count;

        string goodVerbs2 = "!goodverb2!";
        input = baseStory;
        arr = input.Split(new char[] { ' ', '.', '<', '>' });
        count = Array.FindAll(arr, s => s.Equals(goodVerbs2.Trim())).Length;
        goodVerbCount += count;

        string badVerbs2 = "!badverb2!";
        input = baseStory;
        arr = input.Split(new char[] { ' ', '.', '<', '>' });
        count = Array.FindAll(arr, s => s.Equals(badVerbs2.Trim())).Length;
        badVerbCount += count;

        string goodVerbs = "!goodverb!";
        input = baseStory;
        arr = input.Split(new char[] { ' ', '.', '<', '>' });
        count = Array.FindAll(arr, s => s.Equals(goodVerbs.Trim())).Length;
        goodVerbCount += count;


        story.text = fixedStory;

    }
	// Update is called once per frame
	void Update () {

		
	}
}
