using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HudController : MonoBehaviour
{
    [SerializeField] private InventoryManager mgInventory;
    [SerializeField] private Text textPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePointUI();
    }

    void UpdatePointUI()
    {
        int[] pointCount = mgInventory.GetPointQuantity();
        textPoint.text = "x" + pointCount[0];

    }
}
