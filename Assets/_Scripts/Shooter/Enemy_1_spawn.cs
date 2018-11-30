using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_spawn : MonoBehaviour {

    public GameObject prefab_object;
    public int coutn_obj;
    public float seconds;
    private int i = 0;

    void Start () {
        StartCoroutine(Enemy_1_s());
    }
    IEnumerator Enemy_1_s()
    {
        
        while (i < coutn_obj)
        {
            float mins = seconds - 0.6f;
            float maxs = seconds + 5.6f;
            Vector3 pos = new Vector3(-3.45f, Random.Range(-2.4f, 4.4f), 1);
            Instantiate(prefab_object, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(maxs, mins));
            i++;
        }

    }
   
}
