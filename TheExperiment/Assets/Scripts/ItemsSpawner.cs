using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemsSpawner : MonoBehaviour
{
    public Tilemap tileMap;
    public List<GameObject> _items;
    public List<int> _itemsNumber;

    List<Vector3> availablePlaces;


    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        int rnd = 0;
        availablePlaces = new List<Vector3>();
        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }
        for (int i = 0; i < _items.Count; i++)
        {
            for (index = 0; index < _itemsNumber[i]; index++)
            {
                rnd = (int)Random.Range(0f, availablePlaces.Count);
                GameObject go = (GameObject)Instantiate(_items[i]);
                go.transform.position = availablePlaces[rnd];
                availablePlaces.RemoveAt(rnd);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
