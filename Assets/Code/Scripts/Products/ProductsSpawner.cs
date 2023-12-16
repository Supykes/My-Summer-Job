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
    [SerializeField] GameObject damagedCarton1;
    [SerializeField] GameObject damagedCarton2;
    [SerializeField] GameObject damagedBox1;
    [SerializeField] GameObject damagedBox2;
    [SerializeField] GameObject damagedScreen1;
    [SerializeField] GameObject damagedScreen2;

    [Header("Tutorial Note")]
    [SerializeField] GameObject tutorialNote;

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
        if (!TutorialNoteSpawning.spawnedTutorialNoteOnce)
        {
            Invoke(nameof(SpawnTutorialNote), 10f);
        }
        InvokeRepeating(nameof(SpawnProduct), 50f, spawnRepeatRate);
    }

    void PopulateProductsArray()
    {
        products = new GameObject[9] { carton, box, screen, damagedCarton1, damagedCarton2, damagedBox1, damagedBox2, damagedScreen1,
                                        damagedScreen2 };
    }

    void SpawnProduct()
    {
        int randomIndex = Random.Range(0, 9);
        GameObject productToSpawn = products[randomIndex];
        Quaternion productRotation = productToSpawn.transform.rotation;

        Instantiate(productToSpawn, spawnPosition, productRotation, productsParent);
    }

    void SpawnTutorialNote()
    {
        Quaternion tutorialNoteRotation = tutorialNote.transform.rotation;

        Instantiate(tutorialNote, spawnPosition, tutorialNoteRotation);

        TutorialNoteSpawning.spawnedTutorialNoteOnce = true;
    }
}