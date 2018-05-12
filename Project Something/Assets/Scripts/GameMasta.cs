using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasta : MonoBehaviour {
    public static GameMasta TheMasta;

    public Player P1;
    public Player P2;

    public Camera cam;

    public Text clockText;
    public Image winnerDisplay;
    public Image leadMarker;

    public Sprite P1WinSprite;
    public Sprite P2WinSprite;
    public Sprite P1LeadSprite;
    public Sprite P2LeadSprite;

    public Rect gameZone;

    float CountDown = 120;

    bool gameEnded = false;

    bool p1Ahead;
    float aheadSignStartTime;

    // Use this for initialization
    void Start () {
        if (!TheMasta) // I wanna be the masta!
            TheMasta = this; // I'm the masta!
        else
            Destroy(this); // I'm not the masta! This life is not worth living!

        gameZone.width = cam.aspect * 10;
        gameZone.position = new Vector2(-gameZone.width / 2, -5);
	}

    private void Update()
    {
        if (CountDown > 0)
            CountDown -= Time.deltaTime;
        int secondsLeft = Mathf.CeilToInt(CountDown);
        clockText.text = Mathf.Floor(secondsLeft / 60).ToString() + ":" + ((secondsLeft / 10) % 6).ToString() + (secondsLeft % 10).ToString();

        if (CountDown <= 0 && !gameEnded)
            EndGame();

        if (gameEnded && Input.GetKeyDown(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");

        if (P1.points != P2.points && !gameEnded)
        {
            if ((P1.points > P2.points) ^ (p1Ahead))
            {
                aheadSignStartTime = CountDown;
                p1Ahead = !p1Ahead;
                leadMarker.transform.localPosition = new Vector2(-leadMarker.transform.localPosition.x, leadMarker.transform.localPosition.y);

                winnerDisplay.sprite = p1Ahead ? P1LeadSprite : P2LeadSprite;
                winnerDisplay.enabled = true;
            }
        }
        if (aheadSignStartTime > CountDown + 3 && !gameEnded)
            winnerDisplay.enabled = false;
    }

    void EndGame()
    {
        winnerDisplay.sprite = p1Ahead ? P1WinSprite : P2WinSprite;
        winnerDisplay.enabled = true;

        gameEnded = true;
    }
}
