using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SphereHealth : MonoBehaviour, IInvetoryItem
{
    public Sprite _image = null;
    public GameObject _amountText = null;
    public int _amount = 0;
    public int healthIncrease = 0;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject hud;
    public string Name
    {
        get
        {
            return "SphereHealth";
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
        PlayerLife lifes = hud.transform.GetComponent<PlayerLife>();
        Debug.Log(lifes);
        PlayerController player = Player.GetComponent<PlayerController>();
        player.Health += 1;
        lifes.HealLife(healthIncrease);
        FindObjectOfType<AudioManager>().Play("1Up");

    }
}
