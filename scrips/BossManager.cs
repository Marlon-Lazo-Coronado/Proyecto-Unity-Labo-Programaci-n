using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BossManager : MonoBehaviour
{
    public bool bandera;
    //public Text levelCleared2; //Se activa cuando recojemos las frutas

    private void Update()
    {
        AllBossCollected();
    }

    public void AllBossCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan Bosses, Victoria");

            bandera = true;
            //levelCleared2.gameObject.SetActive(true);
            // Invoke("ChangeScene2", 2);                 //Invoca la siguiente ecena
        }

    } 

    void ChangeScene2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
