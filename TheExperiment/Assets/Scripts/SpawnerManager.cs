using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public enum SpawnStatus { SPAWN, WAIT }
    
    private int _easyRate = 1;
    [Header("Easy Portals")] 
    public List<GameObject> EasyPortals;

    private int _mediumRate = 5;
    [Header("Medium Portals")]     
    public List<GameObject> MediumPortals;

    private int _hardRate = 10;
    [Header("Hard Portals")] 
    public List<GameObject> HardPortals;

    private int _bossRate = 15;
    [Header("Boss Portals")] 
    public List<GameObject> BossPortals;

    public float DefaultTimeBetweenWaves = 5.0f;
    [HideInInspector]
    public float TimeBetweenWaves;

    [HideInInspector] public static SpawnStatus Status = SpawnStatus.SPAWN; 

    public int DifficultyIdx = 1;


    private GameObject grid;
    
    private void Awake()
    {
        TimeBetweenWaves = DefaultTimeBetweenWaves;
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void SpawnPickables()
    {
        ItemsSpawner tmp;
        foreach (Transform child in grid.transform)
        {
            tmp = child.GetComponent<ItemsSpawner>();
            if (tmp)
                tmp.Spawn();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBetweenWaves > 0)
        {
            TimeBetweenWaves -= Time.deltaTime;
            if (TimeBetweenWaves <= 0.1f)
            {
                Status = SpawnStatus.WAIT;
                int _difficultyCountDown = DifficultyIdx;
                
                SpawnPickables();
                
                while (_difficultyCountDown > 0)
                {
                    if (_difficultyCountDown > _bossRate && Random.Range(0, 100) > 25)
                    {
                        if (BossPortals.Count > 0)
                        {
                            var child = Instantiate(BossPortals[Random.Range(0, BossPortals.Count)]);
                            child.transform.parent = transform;
                            _difficultyCountDown -= _bossRate;
                        }
                    } else if (_difficultyCountDown > _hardRate && Random.Range(0, 100) > 25)
                    {
                        if (HardPortals.Count > 0)
                        {
                            var child = Instantiate(HardPortals[Random.Range(0, HardPortals.Count)]);
                            child.transform.parent = transform;
                            _difficultyCountDown -= _hardRate;
                        }
                    } else if (_difficultyCountDown > _mediumRate && Random.Range(0, 100) > 25)
                    {
                        if (MediumPortals.Count > 0)
                        {
                            var child = Instantiate(MediumPortals[Random.Range(0, MediumPortals.Count)]);
                            child.transform.parent = transform;
                            _difficultyCountDown -= _mediumRate;
                        }
                    } else
                    {
                        Debug.Log("Instantiating");
                        var child = Instantiate(EasyPortals[Random.Range(0, EasyPortals.Count)], transform);
                        child.SetActive(true);
                        _difficultyCountDown -= _easyRate;
                    }
                }

                DifficultyIdx += 1;
                TimeBetweenWaves = 0;
            }
        }
        else
        {
            if (Status == SpawnStatus.SPAWN)
            {
                TimeBetweenWaves = DefaultTimeBetweenWaves;
                foreach (var portal in GameObject.FindGameObjectsWithTag("Portal"))
                {
                    Destroy(portal.gameObject);
                }
            }
        }
    }
}
