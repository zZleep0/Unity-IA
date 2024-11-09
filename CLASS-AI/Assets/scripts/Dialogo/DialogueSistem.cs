using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSistem : MonoBehaviour
{
    public Text dialogueText; //O texto que sera exibido na tela
    public GameObject[] dialogueOptions; //Opções de respostas do dialogo
    public string[] dialogueLines; //As linhas de dialogo
    public int currentLine = 0; //Linha atual do dialogo

    public string[] dialogueYesOption;
    public string[] dialogueNoOption;
    public Text dialogueYesButton;
    public Text dialogueNoButton;

    // Start is called before the first frame update
    void Start()
    {
        dialogueYesButton = GameObject.Find("Btn Positive").GetComponentInChildren<Text>();
        dialogueNoButton = GameObject.Find("Btn Negative").GetComponentInChildren<Text>();

        dialogueLines = new string[]
        {
            "Olá, aventureiro! Você deseja saber mais sobre este mundo?", // Linha 0
            "Tem certeza que quer saber mais? Podemos começar por onde quiser.", // Linha 1
            "Muito bem, deixe-me te contar sobre o Reino dos Dragões!", // Linha 2
            "O Reino é um lugar misterioso, cheio de lendas e magia.", // Linha 3
            "Você sabia que há uma antiga profecia sobre um herói escolhido?", // Linha 4
            "Dizem que ele virá de terras distantes, mas ninguém sabe exatamente quem é.", // Linha 5
            "Talvez você seja o escolhido! Mas, claro, isso é apenas uma história.", // Linha 6
            "Mas, se preferir, podemos mudar de assunto.", // Linha 7
            "Quem sabe falar sobre os dragões? Eles são criaturas fascinantes.", // Linha 8
            "Os dragões são muito mais inteligentes do que parecem. Alguns dizem que eles falam!", // Linha 9
            "Mas também há quem tenha medo deles, claro.", // Linha 10
            "Agora, se preferir, podemos falar sobre os misteriosos portais do Reino.", // Linha 11
            "Esses portais levam a diferentes dimensões e são muito perigosos para aventureiros inexperientes.", // Linha 12
            "Se você tiver coragem, posso te contar mais sobre os portais...", // Linha 13
            "Ou, talvez, você prefira ir embora e deixar essa conversa para outra hora.", // Linha 14
            "Se for isso que você deseja, entendo. Mas quem sabe no futuro?", // Linha 15
            "Nos encontramos novamente se decidir explorar o Reino mais a fundo.", // Linha 16
            "Espero que tenha gostado de ouvir as histórias. Até logo!", // Linha 17
            "Obrigado por ouvir as lendas, aventureiro. Fique bem!", // Linha 18
            "Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19
        };

        dialogueYesOption = new string[]
        {
            "Sim, me conte mais.", //0
            "Sim, tenho certeza", //1
            "Conte-me mais", //2
            "Interessante", //3
            "Não sabia sobre isso", //4
            "Uau", //5
            "Eu???", //6
            "Pode continuar", //7
            "Realmente são", //8
            "Inacreditável", //9
            "Claro que tem", //10
            "Certo", //11
            "Imagino", //12
            "...", //13
            "Continue sue história", //14
            "Entendido", //15
            "Ok", //16
            "Áté", //17
            "De nada", //18
            "Certo", //19

        };

        dialogueNoOption = new string[]
        {
            "Não, prefiro ir embora",
            "Vamos mudar de assunto",
            "Melhor deixar a conversa para outra hora"
        };

        //Exibe a primeira linha do dialogo
        ShowDialogueLine();

    }

    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            dialogueYesButton.text = dialogueYesOption[currentLine];

            ShowOptions();
        }
        else
        {
            EndDialogue();
        }
    }

    void ShowOptions()
    {
        switch (currentLine)
        {
            case 0: //Primeira linha de dialogo
            case 1:
                dialogueOptions[0].SetActive(true); //Aceitar conversa
                dialogueOptions[1].SetActive(true); //Ir embora
                dialogueYesButton.text = dialogueYesOption[0];
                dialogueNoButton.text = dialogueNoOption[0];
                break;

            case 7: //Quando o jogador pergunta sobre os dragoes
                dialogueOptions[0].SetActive(true); //Aceitar conversa
                dialogueOptions[1].SetActive(true); //Ir embora
                dialogueNoButton.text = dialogueNoOption[1];
                break;
            case 14: //Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); //Aceitar conversa
                dialogueOptions[1].SetActive(true); //Ir embora
                dialogueNoButton.text = dialogueNoOption[2];
                break;

            case 16: //Case o dialogo chegue ao fim
                dialogueOptions[1].SetActive(true); //Apenas a opcao de "ir embora"
                break;

        }
    }

    void EndDialogue()
    {
        dialogueText.text = "O dialogo terminou. Voce pode voltar quando quiser!";
        foreach (GameObject options in dialogueOptions)
        {
            options.SetActive(false); //Aqui os botoes sao desativados quando o dialogo termina
        }
    }

    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: //"Sim, me conte mais!"
                HandlerYesOption();
                break;

            case 1: //"Nao, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); //Atualiza a linha do dialogo
    }

    void HandlerYesOption()
    {
        switch (currentLine)
        {
            case 0: //Primeira linha
            case 1: //Opcao inicial saber mais
                currentLine = 2;
                break;

            case 7:
                currentLine = 8;
                break;

            case 14:
                currentLine = 13;
                break;

            default:
                currentLine += 1;
                break;
        }

        dialogueOptions[1].SetActive(false);

        //currentLine++;
    }

    void HandleNoOption()
    {
        currentLine = 16; //Finaliza o dialogo e diz adeus
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
