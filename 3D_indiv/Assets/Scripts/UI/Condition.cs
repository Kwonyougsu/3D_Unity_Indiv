using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image ConditionBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {     
       ConditionBar.fillAmount = GetPercent();       
    }
    float GetPercent()
    {
        return curValue / maxValue;
    }
    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0.0f);
    }


}
