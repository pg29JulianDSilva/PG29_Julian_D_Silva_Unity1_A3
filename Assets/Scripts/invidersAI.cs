using System.Collections;
using UnityEngine;

public class invidersAI : MonoBehaviour
{

    //objects reference for movement
    [Header("Movement")]
    [SerializeField] private float _shipMovementSpeed = 3f;
    [SerializeField] private float _shipTime = 5f;
    private Transform _shipMovement;
    private Vector3 _shipMovementDirection;
    private Rigidbody _shipMovementRigidbody;
    private int _shipMovementpattern;

    //for the variations
    [Header("Material")]
    public Material[] possibleMaterials;
    [SerializeField] private Renderer theMaterial;

    //for the death
    [Header("Death")]
    [SerializeField] protected string[] _shipstags;
    public int _teams = 0;
    private int _shipsindex;

    private void Start()
    {
        _shipsindex = Random.Range(0, 3);//randomize the value of the ships instance
        gameObject.tag = _shipstags[_shipsindex]; //to assign a tag
        _teams = _shipsindex; //for the teams
        theMaterial.material = possibleMaterials[_shipsindex]; //This if for the material change
        _shipMovement = GetComponent<Transform>();
        _shipMovementDirection = Vector3.zero;
        _shipMovementRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        StartCoroutine(shipDance());
    }

    //This creates the Invader ship movement and manage it to create variations
    private IEnumerator shipDance()
    {
        _shipMovementDirection = _shipMovement.forward * (_shipMovementSpeed * -1);
        _shipMovementRigidbody.AddForce(_shipMovementDirection);
        yield return new WaitForSeconds(_shipTime);
        _shipMovementpattern = Random.Range(-1, 2);
        _shipMovementDirection = _shipMovement.right * (_shipMovementSpeed * _shipMovementpattern);
        _shipMovementRigidbody.AddForce(_shipMovementDirection);
        yield return new WaitForSeconds(_shipTime);
        _shipMovementDirection = _shipMovement.forward * (_shipMovementSpeed * -1);
        _shipMovementRigidbody.AddForce(_shipMovementDirection);
        yield return new WaitForSeconds(_shipTime);
        _shipMovementpattern = Random.Range(-1, 2);
        _shipMovementDirection = _shipMovement.right * (_shipMovementSpeed * _shipMovementpattern);
        _shipMovementRigidbody.AddForce(_shipMovementDirection);
        yield return new WaitForSeconds(_shipTime);
    }


}
