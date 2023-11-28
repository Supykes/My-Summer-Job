using System.Collections.Generic;
using UnityEngine;

public class ProductsManager : MonoBehaviour
{
    public static List<Product> Products;

    void Awake()
    {
        Products = new();
    }
}