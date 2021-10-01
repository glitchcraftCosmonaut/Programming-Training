using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private int scoreAmount;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreAmount.ToString();
    }
    public void AddScore()
    {
        scoreAmount += 10;
    }
    public void decreaseScore()
    {
        scoreAmount -= 10;
    }
}
