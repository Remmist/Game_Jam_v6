using UnityEngine;

public class CollcetibleProgress : MonoBehaviour
{
    [SerializeField] private string collectibleName;
    private Inventory _inventory;
    
    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            if (collectibleName == "Salad")
            {
                FindObjectOfType<PlayerConfig>().MaxHealth = (int)(FindObjectOfType<PlayerConfig>().MaxHealth * 1.5);
                _inventory.Salad = true;
                Debug.Log("Was increased Max Health");
            }
            else if (collectibleName == "Bacon")
            {
                FindObjectOfType<PlayerConfig>().CurrentDamage *= 2;
                Debug.Log("Was increased damage");
                _inventory.Bacon = true;
            }
            else if (collectibleName == "Cheese")
            {
                FindObjectOfType<PlayerMovement>().MoveSpeed *= 1.5f;
                FindObjectOfType<PlayerMovement>().CurrentSpeed = FindObjectOfType<PlayerMovement>().MoveSpeed;
                Debug.Log("Was increased Speed");
                _inventory.Cheese = true;
            }
            Destroy(gameObject);
        }
    }

    public string CollectibleName
    {
        get => collectibleName;
        set => collectibleName = value;
    }
}
