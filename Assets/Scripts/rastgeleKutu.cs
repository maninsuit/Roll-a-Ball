using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rastgeleKutu : MonoBehaviour
{    
    public int numObjects = 12;
    public GameObject prefab;
    private GameObject _Kutular;
    public float uzaklik=2.0f;
    void Start()
    {
        //Seçilen prefabı, orjindeki parent nesneden belirtilen yarıçap kadar uzakta, istenen adette, dairesel sırada sahneye yerleştirir.
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 360/numObjects;
            Vector3 pos = RandomCircle(center, uzaklik ,a);
            _Kutular = Instantiate(prefab, pos,prefab.transform.rotation);
            _Kutular.transform.SetParent(GameObject.Find("Kutular").transform);
            _Kutular.tag="kutu";
        }
    }
    // Merkezden belirli bir yarıçaptaki daire üzerindeki koordinatı belirler.
    Vector3 RandomCircle(Vector3 center, float radius,int a)
    {
        Debug.Log(a);
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + 0.5f;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);;
        return pos;
    }

}
