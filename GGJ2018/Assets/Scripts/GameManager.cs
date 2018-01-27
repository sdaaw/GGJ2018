using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Suspect suspect;

    private float m_timeRemaining;
    [SerializeField]
    private float m_timeToComplete;

    public float score;
    public float difficulty;
    public float strikes;

    public static int caseStoryLevel = 1;

    private bool madeJudgement = false;
    public bool waitingForNext = false;

    [SerializeField]
    private float m_timeBetweenSuspects;

    [SerializeField]
    private Text m_timeText;

    [SerializeField]
    private Text m_scoreText;

    [SerializeField]
    private Image m_layer;

    [SerializeField]
    private List<Sprite> m_torsoList;
    [SerializeField]
    private List<Sprite> m_hairList;
    [SerializeField]
    private List<Sprite> m_eyebrowsList;
    [SerializeField]
    private List<Sprite> m_eyesList;
    [SerializeField]
    private List<Sprite> m_moustacheList;
    [SerializeField]
    private List<Sprite> m_mouthList;

    [SerializeField]
    private List<Color> m_skinColorList;
    [SerializeField]
    private List<Color> m_torsoColorList;
    [SerializeField]
    private List<Color> m_hairColorList;
    [SerializeField]
    private List<Color> m_eyebrowColorList;
    [SerializeField]
    private List<Color> m_eyeColorList;
    [SerializeField]
    private List<Color> m_moustacheColorList;
    [SerializeField]
    private List<Color> m_mouthColorList;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        waitingForNext = true;
    }

    private void Update()
    {
        //start game
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartTrial(20);
        }

        if (m_timeRemaining > 0 && !waitingForNext)
            m_timeRemaining -= Time.deltaTime;
        if (m_timeRemaining <= 0 && !waitingForNext)
        {
            StartCoroutine("FlashScreenRed");
            madeJudgement = true;
            strikes++;
            if (strikes == 3)
                Debug.Log("Game over");
            m_timeRemaining = 0;
        }

        /*if (m_timeRemaining > 0 && !makingJudgement && Input.GetKeyDown(KeyCode.Space))
            Confirm();*/

        UpdateIngameTexts();

    }

    private void UpdateIngameTexts()
    {
        if(m_timeRemaining < 10)
            m_timeText.text = "00:0" + (int)m_timeRemaining;
        else
            m_timeText.text = "00:" + (int)m_timeRemaining;

        m_scoreText.text = "Score: " + (int)score;
    }

    public void StartTrial(float time)
    {
        waitingForNext = false;
        SpawnSuspect();
        m_timeToComplete = time;
        m_timeRemaining = m_timeToComplete;
        madeJudgement = false;
        StartCoroutine("WaitForJudgement");
    }

    /*public void Confirm()
    {
        //makingJudgement = true;
        //player selects between 2 buttons
        StartCoroutine("WaitForJudgement");
    }*/

    private IEnumerator WaitForJudgement()
    {
        //waits until player makes judegement
        yield return new WaitUntil(()=> madeJudgement == true);
        StartCoroutine("WaitForNext"); 
        //StartTrial(m_timeToComplete);
    }


    private IEnumerator WaitForNext()
    {
        waitingForNext = true;
        yield return new WaitForSeconds(m_timeBetweenSuspects);
        waitingForNext = false;
        StartTrial(m_timeToComplete);
    }

    public void MakeJudgement(ButtonType bT)
    {
        bool isGood = (suspect.badVerbCount < suspect.goodVerbCount) ? true : false;

        if (bT == ButtonType.Yes && isGood || bT == ButtonType.No && !isGood)
        {
            score += 10 * difficulty + m_timeRemaining;
            difficulty *= 1.3f;
            if(difficulty > 10) //do smth to this value to balance it when you are more clear I guess lul and why in the fuck am I talking in english ahaha not really talking as Im typing A STOORM, you didn't believe me guys, 1:12 baby till the day I fucking die. Im fucking pumped watching this again!!!!!!
            {
                caseStoryLevel++;
            }
            //TODO: lesser time calculate somehow
        }
        else
        {
            strikes++;
            //flash screen red
            StartCoroutine("FlashScreenRed");
            if (strikes == 3)
                Debug.Log("Game over");

            //TODO: Implement Game Over
        }

        madeJudgement = true;
    }

    private IEnumerator FlashScreenRed()
    {
        m_layer.color = new Color(0.8f,0.1f,0.3f,0.6f);
        yield return new WaitForSeconds(0.2f);
        m_layer.color = new Color(0, 0, 0, 0);
    }

    public void SpawnSuspect()
    {
        //change colors of the sprites?
        //swap the sprites here for new suspect and change story/image in note
        suspect.SetSprites(m_torsoList[Random.Range(0, m_torsoList.Count - 1)],
                           m_hairList[Random.Range(0, m_hairList.Count - 1)],
                           m_eyebrowsList[Random.Range(0, m_eyebrowsList.Count - 1)],
                           m_eyesList[Random.Range(0, m_eyesList.Count - 1)],
                           m_moustacheList[Random.Range(0, m_moustacheList.Count - 1)],
                           m_mouthList[Random.Range(0, m_mouthList.Count - 1)]);

        suspect.SetSpriteColors(m_skinColorList[Random.Range(0,m_skinColorList.Count - 1)],
                                m_torsoColorList[Random.Range(0, m_torsoColorList.Count - 1)],
                                m_hairColorList[Random.Range(0, m_hairColorList.Count - 1)],
                                m_eyebrowColorList[Random.Range(0, m_eyebrowColorList.Count - 1)],
                                m_eyeColorList[Random.Range(0, m_eyeColorList.Count - 1)],
                                m_moustacheColorList[Random.Range(0, m_moustacheColorList.Count - 1)],
                                m_mouthColorList[Random.Range(0, m_mouthColorList.Count - 1)]);

        suspect.AssignPersonality();
    }
}
