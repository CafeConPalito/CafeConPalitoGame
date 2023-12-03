using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cuprefab;
    [SerializeField]
    private GameObject cup;

    // Instancia estática para ser accedida desde cualquier lugar
    public static GameManager instance;

    void Awake()
    {
        // Comprueba si la instancia ya existe
        if (instance == null)
        {
            // Si no, establece la instancia a esta
            instance = this;
        }
        // Si la instancia ya existe y no es esta:
        else if (instance != this)
        {
            // Entonces destruye este objeto. Esto refuerza nuestro patrón Singleton, lo que significa que solo puede haber una instancia de un GameManager.
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(launch());
       
    }

    IEnumerator launch()
    {
        cup = GameObject.Instantiate(cuprefab);
        yield return new WaitForSeconds(5.0f);
    
        cup.GetComponent<SpriteRenderer>().color = Color.red;
        cup.GetComponent<CupController>().isready = true;
      

    }
    

  
}
