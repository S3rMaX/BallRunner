using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("inventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            // Boder... Image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            // We found the empty slot
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;    

                // POSIBLE TODO HERE: Store reference to the item

                break;
            }
        }
    }

    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
       
        Transform inventoryPanel = transform.Find("inventoryPanel");

        foreach (Transform slot in inventoryPanel)
        {
            // Boder... Image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            if (image.sprite == e.Item.Image)
            {
                // We found the empty slot

                image.enabled = false;
                image.sprite = null;
                    
                break;
            }
        }

    }
}
