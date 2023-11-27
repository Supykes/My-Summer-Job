using UnityEngine;

public class ProductsSpawner : MonoBehaviour
{
    [Header("Products Parent")]
    [SerializeField] Transform productsParent;

    [Header("Quality Products To Spawn")]
    [SerializeField] GameObject carton;
    [SerializeField] GameObject box;
    [SerializeField] GameObject screen;

    [Header("Damaged Products To Spawn")]


    float spawnRepeatRate = 10f;
    GameObject[] products;
    Vector3 spawnPosition;

    void Awake()
    {
        PopulateProductsArray();

        spawnPosition = transform.position;
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnProduct), 10f, spawnRepeatRate);
    }

    void PopulateProductsArray()
    {
        products = new GameObject[3] { carton, box, screen };
    }

    void SpawnProduct()
    {
        int randomIndex = Random.Range(0, 3);
        GameObject productToSpawn = products[randomIndex];
        Quaternion productRotation = productToSpawn.transform.rotation;

        Instantiate(productToSpawn, spawnPosition, productRotation, productsParent);
    }
}