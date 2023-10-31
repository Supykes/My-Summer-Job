using UnityEngine;

public class ProductsSpawner : MonoBehaviour
{
    [Header("Products Parent")]
    [SerializeField] Transform productsParent;

    [Header("Products To Spawn")]
    // Change later
    [SerializeField] GameObject product1;
    [SerializeField] GameObject product2;
    [SerializeField] GameObject product3;
    // Change later
    readonly float spawnRepeatRate = 10f;
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
        products = new GameObject[3];

        products[0] = product1;
        products[1] = product2;
        products[2] = product3;
    }

    void SpawnProduct()
    {
        int randomIndex = Random.Range(0, 3);
        GameObject productToSpawn = products[randomIndex];
        Quaternion productRotation = productToSpawn.transform.rotation;

        Instantiate(productToSpawn, spawnPosition, productRotation, productsParent);
    }
}