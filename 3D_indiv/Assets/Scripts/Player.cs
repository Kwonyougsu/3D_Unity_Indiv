using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerControllar controllar;

    private void Awake()
    {
        CharacaterManager.Instance.player = this;
        controllar = GetComponent<PlayerControllar>();
    }
}
