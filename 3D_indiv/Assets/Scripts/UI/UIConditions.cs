using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{
    public Condition Health;
    public Condition Hunger;


    private void Start()
    {
        CharacaterManager.Instance.player.condition.UIConditions = this;
    }
}
