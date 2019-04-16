using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<ItemsList.Type, ItemDetails> items;

    void Start()
    {
        items = new Dictionary<ItemsList.Type, ItemDetails>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ressource")
        {
            var tmp = other.transform.GetComponent<Ressource>();
            if (items.ContainsKey(tmp.type))
            {
                items[tmp.type].quantity = items[tmp.type].quantity + tmp.quantity;
                print(tmp.type + ": " + items[tmp.type].quantity);
            }
            else
            {
                items.Add(tmp.type, new ItemDetails(tmp.quantity, tmp.img));
                print("Added to the inventory " + tmp.type + ": " + tmp.quantity);
            }
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
