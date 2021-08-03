using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DiamanteManager : MonoBehaviour
{
    public BossManager hijosBossmanajer;

    public Text levelCleared; //Se activa cuando recojemos las frutas

    private void Update()
    {
        AllGemasCollected();
    }


    public void AllGemasCollected()
    {
 
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan gemas, Victoria");

            levelCleared.gameObject.SetActive(true);
            if (hijosBossmanajer.bandera)
            {
                Invoke("ChangeScene", 2);                 //Invoca la siguiente ecena
            }
        }
}

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
