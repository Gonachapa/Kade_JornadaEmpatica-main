using UnityEngine;
using UnityEngine.UI;

public class ReduceFillAmount : MonoBehaviour
{
    public Image imageToReduce; // Arraste a imagem aqui pelo Inspector
    private const float reductionAmount = 0.05f; // 5%

    // Método que será chamado quando o botão for clicado
    public void OnButtonClick()
    {
        if (imageToReduce != null)
        {
            imageToReduce.fillAmount -= reductionAmount;
            if (imageToReduce.fillAmount < 0)
            {
                imageToReduce.fillAmount = 0;
            }
        }
    }
}
