using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public Animator animator;
    bool comboPossible;
    int comboStep;
    
    
    public void Attack()
    {
        if(comboStep ==0)
        {
            animator.Play("Punching");
            comboStep = 1;
            return;
        }
        if(comboStep != 0)
        {
            if(comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }
    public void Combo()
    {
        if(comboStep == 2)
        {
            animator.Play("LeftPunch");
        }
        if(comboStep ==3)
        {
            animator.Play("Punching 0");
        }
    }
    public void comboReset()
    {
        comboPossible = false;
        comboStep = 0;
    }
    // private void Update() 
    // {
    //     if(Input.GetMouseButtonDown(0))
    //         Attack();
    // }
}
