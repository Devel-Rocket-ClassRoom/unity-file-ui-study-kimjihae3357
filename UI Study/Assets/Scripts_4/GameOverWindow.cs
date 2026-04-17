using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameOverWindow : GenericWindow
{
    public TextMeshProUGUI leftStatLabel;
    public TextMeshProUGUI leftStatValue;
    public TextMeshProUGUI rightStatLabel;
    public TextMeshProUGUI rightStatValue;
    public TextMeshProUGUI scoreValue;

    public Button nextButton;

    public float statsDelay = 1f;
    public float scoreDuration = 2f;

    private const int totalStats = 6;
    private const int statsPerColum = 3;

    int[] statRolls = new int[totalStats];
    int finalScore;

    private Coroutine routine;

    private TextMeshProUGUI[] statsLabels;
    private TextMeshProUGUI[] statsValues;


    private void Awake()
    {
        statsLabels = new TextMeshProUGUI[] { leftStatLabel, rightStatLabel};
        statsValues = new TextMeshProUGUI[] { leftStatValue, rightStatValue};
        nextButton.onClick.AddListener(OnNext);

    }
    
    private void Update()
    {
        
    }


    public override void Open()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;

        }

        base.Open();
        ResetStats();
        routine = StartCoroutine(CoPlayGameOverRoutine());

    }

    public override void Close()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        base.Close();
    }

    public void OnNext()
    {
        windowManager.Open(0);
    }

  

    private void ResetStats()
    {
        
        for (int i = 0;i < totalStats; i++)
        {
            statRolls[i] = Random.Range(0, 1000);
        }
        finalScore = Random.Range(0, 10000000);

        for (int i = 0; i < statsLabels.Length; i++)
        {
            statsLabels[i].text = string.Empty;
            statsValues[i].text = string.Empty;
        }
        scoreValue.text = $"{0:D9}";
    }

    private IEnumerator CoPlayGameOverRoutine()
    {
        for (int i = 0; i < totalStats; i++)
        {
            yield return new WaitForSeconds(statsDelay);

            int column = i / statsPerColum;
            var labelText = statsLabels[column];
            var valueText = statsValues[column];
            string newline = (i % statsPerColum == 0) ? string.Empty : "\n";
            labelText.text = $"{labelText.text}{newline}Stat {i}";
            valueText.text = $"{valueText.text}{newline}{statRolls[i]:D4}";
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / scoreDuration;
            int current = Mathf.FloorToInt(Mathf.Lerp(0, finalScore, t));
            scoreValue.text = $"{current:D9}";
            yield return null;
        }

        scoreValue.text = $"{finalScore:D9}";
        routine = null;
    }
}
