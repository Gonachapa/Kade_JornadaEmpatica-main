using UnityEngine;
using UnityEngine.UI;

public class Atack : MonoBehaviour
{
    public SpriteRenderer targetObject; // Referência ao objeto cujo sprite será trocado
    public Sprite comparisonObject; // Referência ao objeto para comparação
    public Button[] buttons;  // Array de botões
    public Button finishButton; // Botão "Finish"
    public Button MercyButton; // Botão "Mercy"
    public Sprite[] sprites; // Array de sprites para trocar
    private int currentIndex = 0; // Índice atual da sprite
    public GameObject objectmsg;

    void Start()
    {
        // Adicione listeners aos botões
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Captura o índice atual
            buttons[i].onClick.AddListener(() => ChangeSprite(index));
        }
    }

    void ChangeSprite(int buttonIndex)
    {
        // Verifica se o sprite do targetObject é igual ao do comparisonObject
        if (targetObject.sprite == comparisonObject)
        {
            // Se forem iguais, habilita o botão "Finish"
            finishButton.interactable = true;
            MercyButton.interactable = true;
            for (int i = 0; i < buttons.Length; i++){
                buttons[i].interactable = false;
            }
            objectmsg.SetActive(true);
        }
        else 
        {
            // Se não forem iguais, desabilita o botão "Finish"
            finishButton.interactable = false;
            MercyButton.interactable = false;
            // Troca a sprite do targetObject
            targetObject.sprite = sprites[currentIndex];
            if (targetObject.sprite == comparisonObject)
            {
                // Se forem iguais, habilita o botão "Finish"
                finishButton.interactable = true;
                MercyButton.interactable = true;
                for (int i = 0; i < buttons.Length; i++){
                    buttons[i].interactable = false;
                }
                objectmsg.SetActive(true);
            }
        }

        // Atualiza o índice para a próxima sprite
        currentIndex = (currentIndex + 1) % sprites.Length;
    }
}
