using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
   public float throwStrength;
   private float throwChargeStart;
   private float chargeTime;
   public float maxThrow;

   public GameObject itemInReach;
   public Transform dropPos;
   public void Update()
   {
      if (Input.GetMouseButtonDown(1))
      {
         if (!PickupItem())//if you dont pick up an item than assume player is trying to throw one
         {
            chargeTime = 0;
            throwChargeStart = Time.time;
         }
         else
         {
            chargeTime = -1;//tell it that you picked up an item
         }
      }

      if (Input.GetMouseButtonUp(1) && chargeTime != -1)
      {
         chargeTime = Time.time - throwChargeStart;
         DropItem();
      }
      

   }

   public bool PickupItem()
   {
      GameObject heldItem = GameObject.FindWithTag("Held Item");
      if (heldItem || !itemInReach)
      {
         return false;
      }

      DroppedItemInformation droppedItemInfoScript = itemInReach.GetComponent<DroppedItemInformation>();
      GameObject pickupPrefab = droppedItemInfoScript.heldVarient;
      GameObject newHeldItem = Instantiate(pickupPrefab, transform.GetChild(0));
      newHeldItem.GetComponent<HeldItemInformation>().information = droppedItemInfoScript.information;
      Destroy(itemInReach);
      return true;
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("FloorItem"))
      {
         itemInReach = other.gameObject;
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
      droppedItem.GetComponent<Rigidbody2D>().velocity = transform.right * (throwStrength + Math.Min(chargeTime*maxThrow,maxThrow));
      droppedItem.GetComponent<Rigidbody2D>().AddTorque(60);
      droppedItem.GetComponent<DroppedItemInformation>().information = heldItemInfoScript.information;
      Destroy(heldItem);
   }
}
