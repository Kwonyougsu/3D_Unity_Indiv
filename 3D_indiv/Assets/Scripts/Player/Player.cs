using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerControllar controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action Additem;

    public Transform dropPosition;

    private void Awake()
    {
        CharacaterManager.Instance.player = this;
        controller = GetComponent<PlayerControllar>();
        condition = GetComponent<PlayerCondition>();
    }
}
