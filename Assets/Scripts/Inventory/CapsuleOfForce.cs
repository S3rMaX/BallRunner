using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CapsuleOfForce : MonoBehaviour, IInvetoryItem
{
    public Sprite _image = null;
    public GameObject _amountText = null;
    public int _amount = 0;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject force;
    //Acá pueden incluir un audiosource y un audioclip
    [SerializeField] private float forceSpeed = 30f;
    [SerializeField] private Vector3 direction = new Vector3(0f, 0f, 1f);

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private Transform forceStart;

    private void Start()
    {
        forceStart = GameObject.FindGameObjectWithTag("ForceReference").GetComponent<Transform>();
    }
    public string Name
    {
        get
        {
            return "CapsuleOfForce";
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
        Debug.Log("May the force be with you");
        InstantiateForce();
        FindObjectOfType<AudioManager>().Play("ForceFX");

    }
    private void InstantiateForce()
    {
        GameObject forceInstance = Instantiate(force, forceStart.position, Quaternion.identity);
        forceInstance.GetComponent<Rigidbody>().velocity = (direction).normalized * forceSpeed;
    }
}
