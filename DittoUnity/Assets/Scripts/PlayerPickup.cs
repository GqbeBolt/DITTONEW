using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{


   public GameObject itemInReach;
   public Transform dropPos;
    private PlayerHealth healthController;
    public GameObject[] weapons;

    private void Start()
    {
        healthController = transform.parent.GetComponent<PlayerHealth>();
        GameObject newHeldItem = Instantiate(weapons[PlayerPrefs.GetInt("PlayerHolding")], transform.parent.GetChild(0));
        
    }
    public void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         if (!PickupItem())
         {
            DropItem();
         }
      }
      

   }

   public bool PickupItem()
   {
      GameObject heldItem = GameObject.FindWithTag("Held Item");
      if (!itemInReach)//if theres nothing in reach
      {
         return false;
      }

      if (heldItem)//if you have a held item drop it
      {
         DropItem();
      }

      DroppedItemInformation droppedItemInfoScript = itemInReach.GetComponent<DroppedItemInformation>();
      GameObject pickupPrefab = droppedItemInfoScript.heldVarient;
      GameObject newHeldItem = Instantiate(pickupPrefab, transform.parent.GetChild(0));
      newHeldItem.GetComponent<HeldItemInformation>().information = droppedItemInfoScript.information;
      Destroy(itemInReach);
      switch (newHeldItem.name)
      {
         case "PlayerBow":
            PlayerPrefs.SetInt("PlayerHolding", 0);
            break;
         case "PlayerStaff":
            PlayerPrefs.SetInt("PlayerHolding", 1);
            break;
         case "PlayerSword":
            PlayerPrefs.SetInt("PlayerHolding", 2);
            break;
      }

      
      return true;
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("FloorItem"))
      {
         itemInReach = other.gameObject;
      } else if (other.CompareTag("HealthPack"))
       {
            healthController.Heal(1);
            Destroy(other.gameObject);
       }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject == itemInReach)
      {
         itemInReach = null;
      }
   }

   public void DropItem()
   {
      GameObject heldItem = GameObject.FindWithTag("Held Item");
      if (!heldItem)
      {
         return;
      }

      HeldItemInformation heldItemInfoScript = heldItem.GetComponent<HeldItemInformation>();
      GameObject droppedItem = Instantiate(heldItemInfoScript.droppedVarient,dropPos.position,transform.rotation);
      droppedItem.GetComponent<Rigidbody2D>().velocity = transform.right;
      droppedItem.GetComponent<DroppedItemInformation>().information = heldItemInfoScript.information;
      Destroy(heldItem);
   }
}
