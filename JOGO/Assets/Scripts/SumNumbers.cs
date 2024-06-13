using UnityEngine;
using TMPro;

public class SumNumbers : MonoBehaviour
{
    public TextMeshProUGUI numberText1;
    public TextMeshProUGUI numberText2;
    public TextMeshProUGUI numberText3;
    public TextMeshProUGUI numberText4;
    public TextMeshProUGUI numberText5;
    public TextMeshProUGUI Result;

    void Update()
    {
        // Ler os números dos textos e somá-los
        double sum = (GetNumber(numberText1) * 1.80) + (GetNumber(numberText2) * 1.20) + (GetNumber(numberText3) * 1.80) + (GetNumber(numberText4) * 0.80) + (GetNumber(numberText5) * 1.0);

        // Exibir a soma no TextMeshProUGUI Result
        Result.text = "Value: " + sum;
    }

    // Função para converter o texto para número
    double GetNumber(TextMeshProUGUI textMesh)
    {
        double number;
        if (double.TryParse(textMesh.text, out number))
        {
            return number;
        }
        else
        {
            Debug.LogError("O texto não pôde ser convertido para número: " + textMesh.text);
            return 0;
        }
    }
}
