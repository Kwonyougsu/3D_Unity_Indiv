using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerControllar controllar;
    public PlayerCondition condition;
    private void Awake()
    {
        CharacaterManager.Instance.player = this;
        controllar = GetComponent<PlayerControllar>();
        condition = GetComponent<PlayerCondition>();
    }
}
