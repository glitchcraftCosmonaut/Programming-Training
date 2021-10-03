using UnityEngine;
using UnityEngine.UI;

public class PlayerOnStay : MonoBehaviour
{
    public Text score;
    private int scoreAmount = 0;

    private void Start() 
    {
        score.text = score.ToString();
    }
    private void Update() 
    {
        score.text = scoreAmount.ToString();
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.name == "Cube")
        {
            Debug.Log("stay");
            scoreAmount += 1;
            score.text = scoreAmount.ToString();
        }
    }
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.name == "Cube Col")
        {
            Debug.Log("stay");
            scoreAmount += 1;
            score.text = scoreAmount.ToString();
        }
    }
}
