using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class OyuncuKontrolcusu : MonoBehaviour
{
    // Start is called before the first frame update
    public float hiz, _sure;
    public Text _txtSkor, _txtSonuc, _txtSure;
    public Button _btnYeniOyun, _btnCikis;
    private Rigidbody rb;
    private int sayac, objeAdedi;
    
    //private Time _sure;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objeAdedi = GameObject.Find("Kutular").GetComponent<rastgeleKutu>().numObjects;
        sayac = 0;
        _sure = 0;
        _btnYeniOyun.gameObject.SetActive(false);
        _btnCikis.gameObject.SetActive(false);
        SkorYaz();
        _txtSonuc.text="";
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Çıkış yapılıyor.");
        }
    }
    void FixedUpdate()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        Vector3 hareket = new Vector3(yatayHareket,0.0f,dikeyHareket);

        rb.AddForce(hareket*hiz);  
        _sure = Time.timeSinceLevelLoad; 
        _txtSure.text = _sure.ToString();
    }
    
    // Tetiklenen nesneyi sahneden kaldır.(Pasif hale getir)
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("kutu"))
        {
            other.gameObject.SetActive(false);
            sayac += 1;
            SkorYaz();
        }
    }
    void SkorYaz()
    {
        _txtSkor.text = "Skor : " + sayac.ToString();
        Debug.Log(objeAdedi);
        if(sayac >= objeAdedi && _sure < 10)
        {
            _txtSure.gameObject.SetActive(false);
            _txtSonuc.text="Tebrikler!!! 10 saniyenin altında bitirdiniz. \nSüreniz : " + _sure + "sn";  
            rb.gameObject.SetActive(false);
            _btnYeniOyun.gameObject.SetActive(true);
            _btnCikis.gameObject.SetActive(true);
        }
        else  if(sayac >= objeAdedi && _sure >= 10)
        {
            _txtSure.gameObject.SetActive(false);
            _txtSonuc.text="Oyun bitti... Ancak 10 saniyenin altına inemediniz... \nSüreniz : " + _sure + "sn";
            rb.gameObject.SetActive(false);
            _btnYeniOyun.gameObject.SetActive(true);
            _btnCikis.gameObject.SetActive(true);
        }
    }
    /* public void YeniOyun()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    } */
}
