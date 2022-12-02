using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour, IInvetoryItem
{
    public Sprite _image = null; 
    public GameObject _amountText = null;
    public int _amount = 0;
    public int speedIncrese = 0;
    [SerializeField] private GameObject Player;

    public string Name
    {
        get
        {
            return "SpeedBoost";
        }
    }

    public Sprite Image 
    {
        get
        {
            return _image;
        }
    }

    public GameObject AmountText
    {
        get
        {
            return _amountText;
        }
    }

    public int Amount
    {
        get
        {
            return _amount;
        }
    }

    public void OnDrop()
    {
        throw new System.NotImplementedException();
    }

    public void OnPickUp()
    {
        // Add logic what happends to player when throw this power
        gameObject.SetActive(false);
        AmountText.SetActive(false);
    }

    public void OnUse()
    {
        Debug.Log("usando item de velocidad..");
        PlayerController player = Player.GetComponent<PlayerController>();
        player.IncreaseSpeed(30, 3f);
    }

}
