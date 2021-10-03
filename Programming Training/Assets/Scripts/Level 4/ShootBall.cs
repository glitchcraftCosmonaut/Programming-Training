using UnityEngine;
using UnityEngine.UI;

public class ShootBall : MonoBehaviour
{
    public GameObject ball;
    GameObject ballClone;
    public Text score;
    public Text highScore;
    private int scoreAmount = 0;
    private int highScoreAmmount = 0;
    void Start()
    {
        highScoreAmmount = PlayerPrefs.GetInt("highscore", 0);
        score.text = score.ToString();
        highScore.text = highScoreAmmount.ToString();
        // score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreAmount.ToString();
    }
    public void ShootingBall()
    {
        ballClone = Instantiate(ball, transform.position, transform.rotation) as GameObject;
        Destroy(ballClone, 1f);
        scoreAmount += 10;
        score.text = scoreAmount.ToString();
        if(highScoreAmmount < scoreAmount)
            PlayerPrefs.SetInt("highscore", scoreAmount);
    }
}
