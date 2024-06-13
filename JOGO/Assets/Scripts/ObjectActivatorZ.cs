using UnityEngine;
using System.Collections.Generic;

public class ObjectActivatorZ : MonoBehaviour
{
    public List<GameObject> objectsToToggle; // Lista de objetos a serem alternados

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleActiveState();
        }
    }

    private void ToggleActiveState()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf); // Alterna o estado ativo de cada objeto na lista
        }
    }
}
