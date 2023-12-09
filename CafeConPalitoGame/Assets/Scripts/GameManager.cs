using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cuprefab;
    [SerializeField]
    private TMP_Text scoretext;
    [SerializeField]
    private GameObject random;
    private Transform positionrandom;
    [SerializeField]
    private GameObject macu;
    private Transform positionmacu;

    private GameObject cup;

    

    public int score =0;
    public bool cafeisready = false;

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
        positionmacu=macu.GetComponent<Transform>();
        positionrandom= random.GetComponent<Transform>();
       
    }

    private void Update()
    {
        scoretext.SetText("Score: "+ score);
        if (cafeisready)
        {
            cafeisready=false;
            StartCoroutine(GoToRandomCafe());
            StartCoroutine(GoToRandomExit());

        }
    }

    IEnumerator launch()
    {
        cup = GameObject.Instantiate(cuprefab);
        yield return new WaitForSeconds(Random.Range(2f,8f));
    
        cup.GetComponent<SpriteRenderer>().color = Color.red;
        cup.GetComponent<CupController>().isready = true;

    }
    private IEnumerator GoToRandomCafe()
    {

        while (random.transform.position != cup.transform.position)
        {
            random.transform.position = UnityEngine.Vector3.MoveTowards(random.transform.position, cup.transform.position, Time.deltaTime * 10);
            yield return null;
        }

    }
    private IEnumerator GoToRandomExit()
    {

        while (random.transform.position != positionrandom.position)
        {
            random.transform.position = UnityEngine.Vector3.MoveTowards(random.transform.position, positionrandom.position, Time.deltaTime * 10);
            yield return null;
        }

    }



}
