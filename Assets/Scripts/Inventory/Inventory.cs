using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private IInvetoryItem mItems = null;

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public event EventHandler<InventoryEventArgs> ItemUse;

    public void AddItem(IInvetoryItem item)
    {

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                mItems = item;

                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
    }

    internal void UseItem(IInvetoryItem item)
    {
        item.OnUse();
    }

    public IInvetoryItem GetItem()
    {
        return mItems;
    }

    public void RemoveItem(IInvetoryItem item)
    {
        if (mItems == item)
        {
            mItems = null;

            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item)) ;
            }

            // keep going, this function is incomplete
        }
    }

}
