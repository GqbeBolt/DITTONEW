using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class PlayerPickup : MonoBehaviour
{


   public GameObject itemInReach;
   public Transform dropPos;
    private PlayerHealth healthController;
    public GameObject[] weapons;
    [SerializeField] private TMP_Text text;
    private MoveController moveController;

    private void Start()
    {
        healthController = transform.parent.GetComponent<PlayerHealth>();
        GameObject heldItem = GameObject.FindWithTag("Held Item");
        if (heldItem)
        {
           return;
        } //if you have a held item drop it}

        GameObject newHeldItem = Instantiate(weapons[PlayerPrefs.GetInt("PlayerHolding")], transform.parent.GetChild(0));
        moveController = GetComponentInParent<MoveController>();
        switch (newHeldItem.name)
        {
            case "PlayerBow(Clone)":
                moveController.changeJumpHeight(25f);
                moveController.changeJumpAmount(2);
                moveController.changeSpeed(10f);
                break;
            case "Player Staff(Clone)":
                moveController.changeJumpHeight(15f);
                moveController.changeJumpAmount(3);
                moveController.changeSpeed(10f);
                break;
            case "PlayerSword(Clone)":
                moveController.changeJumpHeight(15f);
                moveController.changeJumpAmount(2);
                moveController.changeSpeed(16f);
                break;
        }

        
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


      if (heldItem)
      {
         DropItem(true);
      }   
      heldItem = GameObject.FindWithTag("Held Item");
      if (heldItem && heldItem.name == "PlayerPunch(Clone)")//if you have a held item drop it
      {
         Destroy(heldItem);
      }

      DroppedItemInformation droppedItemInfoScript = itemInReach.GetComponent<DroppedItemInformation>();
      GameObject pickupPrefab = droppedItemInfoScript.heldVarient;
      GameObject newHeldItem = Instantiate(pickupPrefab, transform.parent.GetChild(0));
      newHeldItem.GetComponent<HeldItemInformation>().information = droppedItemInfoScript.information;
      Destroy(itemInReach);
      switch (newHeldItem.name)
      {
         case "PlayerBow(Clone)":
            PlayerPrefs.SetInt("PlayerHolding", 1);
            moveController.changeJumpHeight(25f);
            moveController.changeJumpAmount(2);
            moveController.changeSpeed(10f);
            break;
         case "Player Staff(Clone)":
            PlayerPrefs.SetInt("PlayerHolding", 2);
            moveController.changeJumpHeight(15f);
            moveController.changeJumpAmount(3);
            moveController.changeSpeed(10f);
            break;
         case "PlayerSword(Clone)":
            PlayerPrefs.SetInt("PlayerHolding", 3);
            moveController.changeJumpHeight(15f);
            moveController.changeJumpAmount(2);
            moveController.changeSpeed(16f);
            break;
      }

      
      return true;
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("FloorItem"))
      {
         itemInReach = other.gameObject;
         text.text = "<E to Pickup>";
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
            text.text = "";
      }
   }

   public void DropItem()
   {
      GameObject heldItem = GameObject.FindWithTag("Held Item");
      if (!heldItem || heldItem.name == "PlayerPunch(Clone)")
      {
         return;
      }

      HeldItemInformation heldItemInfoScript = heldItem.GetComponent<HeldItemInformation>();
      GameObject droppedItem = Instantiate(heldItemInfoScript.droppedVarient,dropPos.position,transform.rotation);
      droppedItem.GetComponent<Rigidbody2D>().velocity = transform.right*3;
      droppedItem.GetComponent<DroppedItemInformation>().information = heldItemInfoScript.information;
      Destroy(heldItem);
      PlayerPrefs.SetInt("PlayerHolding", 0);
      Instantiate(weapons[0], transform.parent.GetChild(0));
      moveController.changeJumpHeight(15f);
      moveController.changeJumpAmount(2);
      moveController.changeSpeed(12f);
   }
   public void DropItem(bool idk)
   {
      GameObject heldItem = GameObject.FindWithTag("Held Item");
      if (!heldItem || heldItem.name == "PlayerPunch(Clone)")
      {
         return;
      }

      HeldItemInformation heldItemInfoScript = heldItem.GetComponent<HeldItemInformation>();
      GameObject droppedItem = Instantiate(heldItemInfoScript.droppedVarient,dropPos.position,transform.rotation);
      droppedItem.GetComponent<Rigidbody2D>().velocity = transform.right*3;
      droppedItem.GetComponent<DroppedItemInformation>().information = heldItemInfoScript.information;
      Destroy(heldItem);
      PlayerPrefs.SetInt("PlayerHolding", 0);
      moveController.changeJumpHeight(15f);
      moveController.changeJumpAmount(2);
      moveController.changeSpeed(12f);
   }
}
