using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GameManager : MonoBehaviour
{

    public Transform playerSpawnPoint; // Punto de Inicio Jugador
    public GameObject player;
    private static GameManager _instance;
    public GameObject vCam;
    public static GameManager instance {get {return _instance;} }

    private void Awake() {
        if (_instance == null) _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerSpawnPoint.position;
        vCam = GameObject.FindGameObjectWithTag("VCam");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
