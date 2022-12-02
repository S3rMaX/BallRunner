using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    
    private List<GameObject> inventoryOne;

    [SerializeField] private int[] pointQuantity = { 0, 0, 0 };


    // Start is called before the first frame update
    void Start()
    {
        inventoryOne = new List<GameObject>();
    }

    public int [] GetPointQuantity()
    {
        return pointQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryOne(GameObject item)
    {
        inventoryOne.Add(item);
    }

    public void RemoveInventoryOne(int amount)
    {
        pointQuantity[0] -= amount;
    }

    public List<GameObject> GetInventoryOne()
    {
        return inventoryOne;
    }

    public void CountPoint (GameObject point)
    {
        CoinController p = point.GetComponent<CoinController>();


        switch (p.GetTypesPoints())
        {
            case GameManager.typesPoints.Yellow:
                pointQuantity[0]++;
                break;
            case GameManager.typesPoints.Red:
                pointQuantity[1]++;
                break;
            default:
                Debug.Log("No se puede contar");
                break;
        }
    }

}
