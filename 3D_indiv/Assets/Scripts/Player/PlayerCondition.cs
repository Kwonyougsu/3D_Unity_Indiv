using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UIConditions UIConditions;

    Condition health { get { return UIConditions.Health; } }
    Condition hunger { get { return UIConditions.Hunger; } }

    public float noHungerHealthDecay;

    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);

        if (hunger.curValue <= 0.0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue < 0.0f)
        {
            Debug.Log("Die");
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }
}
