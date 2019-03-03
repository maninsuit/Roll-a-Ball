using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yeniOyun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void YeniOyun()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
    public void Cikis()
    {        
        Application.Quit();
        Debug.Log("Çıkış yapılıyor.");
    }
}
