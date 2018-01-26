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

    public bool makingJudgement = false;

    public bool madeJudgement = false;

    [SerializeField]
    private float m_timeBetweenSuspects;

    [SerializeField]
    private Text m_timeText;

    [SerializeField]
    private Text m_scoreText;

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

    private void Awake()
    {

    }

    private void Update()
    {
        //start game
        if (Input.GetKeyDown(KeyCode.Alpha1) && !makingJudgement)
            StartTrial(20);

        if (m_timeRemaining > 0 && !makingJudgement)
            m_timeRemaining -= Time.deltaTime;
        if (m_timeRemaining <= 0)
            m_timeRemaining = 0;

        if (m_timeRemaining > 0 && !makingJudgement && Input.GetKeyDown(KeyCode.Space))
            Confirm();

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
        SpawnSuspect();
        m_timeToComplete = time;
        m_timeRemaining = m_timeToComplete;
        madeJudgement = false;
        makingJudgement = false;
    }

    public void Confirm()
    {
        makingJudgement = true;
        //player selects between 2 buttons
        StartCoroutine("WaitForJudgement");
    }

    private IEnumerator WaitForJudgement()
    {
        //waits until player makes judegement
        yield return new WaitUntil(()=> madeJudgement == true);
        StartCoroutine("WaitForNext"); 
    }

    private IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(m_timeBetweenSuspects);
        StartTrial(m_timeToComplete);
    }

    public void MakeJudgement(ButtonType bT)
    {
        if (bT == ButtonType.Yes)
            Debug.Log("voted for trump");
        else
            Debug.Log("voted for putin");

        //set score/streaks accordingly and add difficulty, reduce time
        score += 10 * difficulty;
        difficulty *= 1.3f;

        //strikes++;
        if (strikes == 3)
            Debug.Log("Game over");

        madeJudgement = true;
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

    }
}
