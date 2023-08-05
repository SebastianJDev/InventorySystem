using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = InventoryManager.instance.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("ITEM ADED");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }
    }
    public void GetSelectedItem()
    {
        Item recivedItem = InventoryManager.instance.GetSelectedItem(false);
        if (recivedItem != null)
        {
            Debug.Log("Recived Item: " + recivedItem);
        }
        else
        {
            Debug.Log("No Item Recived");
        }
    }
    public void UseSelectedItem()
    {
        Item recivedItem = InventoryManager.instance.GetSelectedItem(true);
        if (recivedItem != null)
        {
            Debug.Log("Used Item: " + recivedItem);
        }
        else
        {
            Debug.Log("No Item Used!");
        }
    }
}
