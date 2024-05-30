using Unity.VisualScripting;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;


    public string GetInteractPrompt()
    {
        string str = $"{data.DisplayName}\n{data.Discruption}";
        return str;
    }

    public void OnInteract()
    {
        CharacaterManager.Instance.player.itemData = data;
        CharacaterManager.Instance.player.Additem?.Invoke();
        Destroy(gameObject);
    }
}