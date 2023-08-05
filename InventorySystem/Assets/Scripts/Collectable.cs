using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Item[] itemsToPickup;
    public float speed;
    public int id;
    private bool mover = false;
    private Collider2D coll;

    private void Update()
    {
        Move(coll);
    }
    public void PickupItem(int id)
    {
        bool result = InventoryManager.instance.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mover = true;
            coll = collision;
        }
    }

    public void Move(Collider2D collision)
    {
        if (mover)
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position,speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,collision.transform.position) == 0)
            {
                PickupItem(id);
            }
        }
    }
}
