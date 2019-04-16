using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetails
{
    public int quantity;
    public Sprite img;

    public ItemDetails(int _quantity, Sprite _img)
    {
        quantity = _quantity;
        img = _img;
    }
}
