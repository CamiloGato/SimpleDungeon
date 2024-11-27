using Player;
using UI;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public ItemsController itemsController;

    private void Start()
    {
        itemsController.AddSubscriptions();
        itemsController.Initialize();
        playerInventory.Initialize();
    }
}