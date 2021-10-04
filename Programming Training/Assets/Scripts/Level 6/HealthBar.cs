using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject screenCondition;
    // [HideInInspector] public float hp;
    [SerializeField] public float maxHp;

    private void Start()
    {
        maxHp = healthSlider.value;
        // hp = maxHp;//At the beginning of the game, The hp is the maxHp
    }

    private void Update()
    {
        // maxHp = hp;
        healthSlider.value = maxHp;
        if(maxHp <= 0)
        {
            new WaitForSeconds(1f);
            screenCondition.SetActive(true);
        }
    }


}
