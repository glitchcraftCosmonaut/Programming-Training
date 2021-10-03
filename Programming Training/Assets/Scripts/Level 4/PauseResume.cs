using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject shootingBall;
    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            shootingBall.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            shootingBall.gameObject.SetActive(true);
        }
    }
}
