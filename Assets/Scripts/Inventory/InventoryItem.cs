using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInvetoryItem
{
    string Name { get; }

    Sprite Image { get; }

    GameObject AmountText { get; }

    int Amount { get; }

    void OnPickUp();

    void OnDrop();

    void OnUse();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInvetoryItem item)
    {
        Item = item;
    }
    public IInvetoryItem Item;
}

