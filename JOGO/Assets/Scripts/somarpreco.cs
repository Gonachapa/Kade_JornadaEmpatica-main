using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class somarpreco : MonoBehaviour
{
    public TextMeshProUGUI numberText; // Referência ao TextMeshPro que exibe o número

    private int number = 0; // Número a ser exibido

    private void Start()
    {
        // Atualiza o número exibido inicialmente
        UpdateNumberText();
    }

    public void OnButtonClickSUM()
    {
        // Lê o valor atual na variável numberText.text e converte para int
        int currentNumber = int.Parse(numberText.text);
        
        // Soma 1 ao valor lido
        currentNumber += 1;
        
        // Atualiza o número
        number = currentNumber;
        UpdateNumberText();
    }

    public void OnButtonClickSUB()
    {
        // Lê o valor atual na variável numberText.text e converte para int
        int currentNumber = int.Parse(numberText.text);
        
        // Subtrai 1 do valor lido, garantindo que não seja menor que zero
        currentNumber = Mathf.Max(0, currentNumber - 1);
        
        // Atualiza o número
        number = currentNumber;
        UpdateNumberText();
    }

    private void UpdateNumberText()
    {
        // Atualiza o número exibido no TextMeshPro
        numberText.text = number.ToString();
    }
}
