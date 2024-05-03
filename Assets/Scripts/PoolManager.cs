using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    private void Awake() {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++) {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) {
        GameObject select = GetGameobject(index);
        
        if (select == null) {
            select = Instantiate(prefabs[index], transform);
            select.SetActive(true);
            pools[index].Add(select);
        }

        return select;
    }

    public GameObject Get(int index, Vector3 position) {
        GameObject select = GetGameobject(index);
        
        if (select == null) {
            select = Instantiate(prefabs[index], position, quaternion.identity);
            select.SetActive(true);
            pools[index].Add(select);
        }

        return select;
    }

    private GameObject GetGameobject(int index) {
        GameObject select = null;

        foreach (GameObject item in pools[index]) {
            if (!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        return select;
    }
}