using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject objeto;

    void Update()
    {
            AtivarObjeto();
    }

    void AtivarObjeto()
    {
        objeto.SetActive(true);

    }

}
