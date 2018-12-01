using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Serializable classes
[System.Serializable]
public class EnemyOne
{
    public GameObject enemy;
    
    public float seconds;
    public int coutn_obj;
   // public bool direction;
    public float xPosMax;
    public float xPosMin;
    public float yPosMin;
    public float yPosMax;
    public float timeToStart;
}
#endregion
/*#region
[System.Serializable]
public class EnemyTwo
{
    public GameObject enemy;
   // public float timeToStart;
    public float seconds;
    public int coutn_obj;
    public bool direction;
}
#endregion
*/
public class Enemy_1_spawn : MonoBehaviour {

   // public GameObject prefab_object;
    //public int coutn_obj;
    // public float seconds;
   // private float direction;
    private int i = 0;
    Vector3 pos;
    public EnemyOne[] enemyOnes;
  //  public EnemyTwo[] enemyTwos;

    private void Awake()
    {
      //  direction = GetComponent<Transform>().localScale.x;
    }

    void Start () {
        for (int i = 0; i < enemyOnes.Length; i++)
            StartCoroutine(Enemy_1_s(enemyOnes[i].enemy, enemyOnes[i].seconds, enemyOnes[i].coutn_obj, enemyOnes[i].xPosMin, enemyOnes[i].xPosMax, enemyOnes[i].yPosMin, enemyOnes[i].yPosMax, enemyOnes[i].timeToStart));
       /* for (int i = 0; i < enemyTwos.Length; i++)
            StartCoroutine(Enemy_1_s(enemyTwos[i].enemy, enemyTwos[i].seconds, enemyTwos[i].coutn_obj, enemyTwos[i].direction));*/

    }
    IEnumerator Enemy_1_s(GameObject enemyprefab, float seconds, int coutn_obj, float xPositMin, float xPositMax,float yPMin, float yPMax, float delay)
    {
        
        while (i < coutn_obj)
        {
            yield return new WaitForSeconds(delay);
            float mins = seconds - 0.6f;
            float maxs = seconds + 5.6f;
            
                pos = new Vector3(Random.Range(xPositMin, xPositMax), Random.Range(yPMin, yPMax), 1);
           
            
            Instantiate(enemyprefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(maxs, mins));
            i++;
        }

    }
   
}
