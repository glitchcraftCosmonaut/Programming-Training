using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Timer timer;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        // timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.timer < 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
