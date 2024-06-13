using UnityEngine;

public class CanvasActivator2 : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    public GameObject canvas;
    public GameObject[] objectsToActivate;

    void Update()
    {
        // Verifica se a tecla "Z" foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Inverte a visibilidade do canvas
            canvas.SetActive(!canvas.activeSelf);

            // Percorre todos os objetos no array e inverte a visibilidade de cada um
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}
