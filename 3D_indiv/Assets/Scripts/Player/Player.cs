using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public PlayerControllar controllar;
    public PlayerCondition condition;

    public Vector3 initialPosition;

    public ItemData itemData;
    public Action Additem;
    private void Awake()
    {
        CharacaterManager.Instance.player = this;
        controllar = GetComponent<PlayerControllar>();
        condition = GetComponent<PlayerCondition>();
    }
}
