using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 3f;
    [SerializeField] private float limitSpeed = 350f;
    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private InventoryManager mgInventory;

    [SerializeField] private GameObject lightTarget;
    [SerializeField] private GameObject spawnPointLvl02;
    [SerializeField] private GameObject spawnPointLvl03;
    [SerializeField] private GameObject spawnPointLvl04;
    [SerializeField] private GameObject winningHud;

    [SerializeField] private GameObject inventoryPanel;

    private Quaternion defaultRotation;

    private PlayerLife mPlayerLife;

    public Inventory inventory;

    public HUD Hud;

    public int Health;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;



    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        mgInventory = GetComponent<InventoryManager>();

        inventory.ItemUse += Inventory_ItemUse;
        mPlayerLife = Hud.transform.Find("LifesPanel").GetComponent<PlayerLife>();

        defaultRotation = transform.rotation;

        winningHud.SetActive(false);

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UsePower();
        }

        if (speedPlayer > limitSpeed)
        {
            speedPlayer = limitSpeed;
        }
    }

    private void Inventory_ItemUse(object sender, InventoryEventArgs e)
    {
        IInvetoryItem item = e.Item;

        
        item.OnUse();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovementPlayer();
    }

    void MovementPlayer()
    {
        float horizontalaxis = Input.GetAxis("Horizontal");
        float verticalaxis = Input.GetAxis("Vertical");
        rbPlayer.AddForce(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime, ForceMode.Impulse);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {            
            GameObject point = other.gameObject;
            point.SetActive(false);
            mgInventory.AddInventoryOne(point);
            mgInventory.CountPoint(point);

            source.PlayOneShot(clip);
        }

        if (other.gameObject.CompareTag("FinalPortal1"))
        {
            GameManager.instance.SwitchLevel();
            transform.position = spawnPointLvl02.transform.position;
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (other.gameObject.CompareTag("FinalPortal2"))
        {
            GameManager.instance.SwitchLevel();
            transform.position = spawnPointLvl03.transform.position;
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (other.gameObject.CompareTag("FinalPortal3"))
        {
            GameManager.instance.SwitchLevel();
            transform.position = spawnPointLvl04.transform.position;
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (other.gameObject.CompareTag("FinalPortal4"))
        {
            winningHud.SetActive(true);
            FindObjectOfType<AudioManager>().Play("PortalJump");
            FindObjectOfType<AudioManager>().Play("Winning");
        }


        if (other.gameObject.CompareTag("Item"))
        {
            TextMesh text = other.gameObject.transform.GetChild(0).GetComponent<TextMesh>();
            IInvetoryItem InventoryItem = inventory.GetItem();

            int powerAmount = int.Parse(text.text.Replace("x", ""));
            int pointCount = mgInventory.GetPointQuantity()[0];
            IInvetoryItem item = other.GetComponent<IInvetoryItem>();
            if (InventoryItem != null) //  it's by index of the list Items
            {
                Debug.Log("count before: " + InventoryItem);   
                if (InventoryItem.Image.name == item.Image.name)
                {
                    if (powerAmount <= pointCount) // Ask if has the money to buy the item/power
                    {
                        if (item != null)
                        {
                            inventory.AddItem(item);
                            Debug.Log("count after: " + InventoryItem);

                            mgInventory.RemoveInventoryOne(powerAmount);
                            Debug.Log("left coins: " + mgInventory.GetPointQuantity()[0]);
                        }
                    }
                    else
                    {
                        Debug.Log("No Tienes suficiente dinero");
                    }
                }
            }  
            else if(InventoryItem == null)
            {
                if (powerAmount <= pointCount) // Ask if has the money to buy the item/power
                {
                    if (item != null)
                    {
                        inventory.AddItem(item);
                        Debug.Log("count after: " + InventoryItem);

                        mgInventory.RemoveInventoryOne(powerAmount);
                        Debug.Log("left coins: " + mgInventory.GetPointQuantity()[0]);
                    }
                }
                else
                {
                    Debug.Log("No Tienes suficiente dinero");
                }
            }
            else
            {
                Debug.Log("Tu inventario esta lleno");
            }
        }
    }
    private void UsePower()
    {
        IInvetoryItem InventoryItem = inventory.GetItem();
        if (InventoryItem != null)
        {
            Transform itemPanelTransform = inventoryPanel.transform.GetChild(0);
            // Boder... Image
            Image image = itemPanelTransform.GetChild(0).GetChild(0).GetComponent<Image>();
            if (InventoryItem != null)
            {
                IInvetoryItem item = InventoryItem;
                if (image.sprite.name == item.Image.name)
                {
                    // Set slot

                    image.enabled = false;
                    image.sprite = null;
                    inventory.UseItem(item);
                    inventory.RemoveItem(item);
                }
            }
            else
            {
                Debug.Log("No tienes un item en ese slot");
            }
        }
    }
    
    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        if (Health < 0)
        {
            Health = 0;
            mPlayerLife.TakeDamage(dmg);

        }
    }

    public void IncreaseSpeed(int newSpeed, float coolDown)
    {
        float oldSpeed = speedPlayer;
        speedPlayer += newSpeed;
        StartCoroutine(speedBoostDuration(coolDown, newSpeed));
    }

    // Coroutines

    IEnumerator speedBoostDuration(float coolDown, float oldSpeed)
    {
        yield return new WaitForSeconds(coolDown);
        speedPlayer -= oldSpeed;
    }
}
