using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSistem : MonoBehaviour
{
    public Text dialogueText; //O texto que sera exibido na tela
    public GameObject[] dialogueOptions; //Op��es de respostas do dialogo
    public string[] dialogueLines; //As linhas de dialogo
    public int currentLine = 0; //Linha atual do dialogo

    public string[] dialogueYesOption;
    public string[] dialogueNoOption;
    public Text dialogueYesButton;
    public Text dialogueNoButton;

    public Vector3 positiveButtonPosition;
    public Vector3 negativeButtonPosition;

    public int pontuacao;
    public Text txtpontuacao;

    public Image imagem1;
    public Image imagem2;

    // Start is called before the first frame update
    void Start()
    {
        imagem2.gameObject.SetActive(false);

        dialogueYesButton = GameObject.Find("Btn Positive").GetComponentInChildren<Text>();
        dialogueNoButton = GameObject.Find("Btn Negative").GetComponentInChildren<Text>();

        // Captura as posi��es iniciais dos bot�es
        Vector3 originalPositionYes = GameObject.Find("Btn Positive").GetComponent<RectTransform>().anchoredPosition;
        Vector3 originalPositionNo = GameObject.Find("Btn Negative").GetComponent<RectTransform>().anchoredPosition;

        // Salva as posi��es iniciais
        positiveButtonPosition = originalPositionYes;
        negativeButtonPosition = originalPositionNo;

        dialogueLines = new string[]
        {
            //"Ol�, aventureiro! Voc� deseja saber mais sobre este mundo?", // Linha 0
            //"Tem certeza que quer saber mais? Podemos come�ar por onde quiser.", // Linha 1
            //"Muito bem, deixe-me te contar sobre o Reino dos Drag�es!", // Linha 2
            //"O Reino � um lugar misterioso, cheio de lendas e magia.", // Linha 3
            //"Voc� sabia que h� uma antiga profecia sobre um her�i escolhido?", // Linha 4
            //"Dizem que ele vir� de terras distantes, mas ningu�m sabe exatamente quem �.", // Linha 5
            //"Talvez voc� seja o escolhido! Mas, claro, isso � apenas uma hist�ria.", // Linha 6
            //"Mas, se preferir, podemos mudar de assunto.", // Linha 7
            //"Quem sabe falar sobre os drag�es? Eles s�o criaturas fascinantes.", // Linha 8
            //"Os drag�es s�o muito mais inteligentes do que parecem. Alguns dizem que eles falam!", // Linha 9
            //"Mas tamb�m h� quem tenha medo deles, claro.", // Linha 10
            //"Agora, se preferir, podemos falar sobre os misteriosos portais do Reino.", // Linha 11
            //"Esses portais levam a diferentes dimens�es e s�o muito perigosos para aventureiros inexperientes.", // Linha 12
            //"Se voc� tiver coragem, posso te contar mais sobre os portais...", // Linha 13
            //"Ou, talvez, voc� prefira ir embora e deixar essa conversa para outra hora.", // Linha 14
            //"Se for isso que voc� deseja, entendo. Mas quem sabe no futuro?", // Linha 15
            //"Nos encontramos novamente se decidir explorar o Reino mais a fundo.", // Linha 16
            //"Espero que tenha gostado de ouvir as hist�rias. At� logo!", // Linha 17
            //"Obrigado por ouvir as lendas, aventureiro. Fique bem!", // Linha 18
            //"Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19

            "Ol�, voc� gostaria de jogar um jogo divertido, as regras s�o simples, voc� responde minhas perguntas corretamente, voc� vive, caso contr�rio, algo de ruim ir� acontecer.", //0
            "Voc� j� sentiu como se estivesse sendo observado, mesmo estando sozinho?", //1
            "Se voc� visse algo imposs�vel, voc� enfrentaria ou fugiria?", //2
            "Voc� j� ouviu seu nome ser sussurrado no sil�ncio?", //3
            "Se tivesse que escolher, voc� se salvaria ou salvaria outro?", //4
            "Voc� acredita que o medo pode te proteger ou ele s� te enfraquece?", //5
            "Voc� acredita que o passado pode ser apagado... ou ele sempre volta para assombrar?", //6
            "Voc� j� fez algum mal para algu�m?", //7
            "Voc� acha que merecia estar vivo?", //8
            "Voc� ainda acha que est� vivo?", //9
            "Acha que os mortos podem se lembrar de suas �ltimas palavras?", //10
            "Qual � seu maior arrependimento", //11
            "Voc� est� sozinho na rua e tem uma pessoa encapuzada, qual sua rea��o?", //12
            "� o fim da linha pra voc� agora, gostou de brincar?", //13
        };


        dialogueYesOption = new string[]
        {
            //"Sim, me conte mais.", //0
            //"Sim, tenho certeza", //1
            //"Conte-me mais", //2
            //"Interessante", //3
            //"N�o sabia sobre isso", //4
            //"Uau", //5
            //"Eu???", //6
            //"Pode continuar", //7
            //"Realmente s�o", //8
            //"Inacredit�vel", //9
            //"Claro que tem", //10
            //"Certo", //11
            //"Imagino", //12
            //"...", //13
            //"Continue sue hist�ria", //14
            //"Entendido", //15
            //"Ok", //16
            //"�t�", //17
            //"De nada", //18
            //"Certo", //19

            "Ok *gulp*", //0
            "Acho que sim...", //1
            "Eu fugiria", //2
            "Sim, uma vez", //3
            "Me salvaria", //4
            "Ele pode me proteger", //5
            "O passado sempre volta para assombrar", //6
            "Infelizmente sim.", //7
            "N�o", //8
            "N�o", //9
            "Sim", //10

        };

        dialogueNoOption = new string[]
        {
            //"N�o, prefiro ir embora",
            //"Vamos mudar de assunto",
            //"Melhor deixar a conversa para outra hora"

            "Na verdade acho que n�o quero, parece perigoso", //0
            "Nunca senti isso", //1
            "Eu enfrentaria", //2
            "Nunca", //3
            "Salvaria o outro", //4
            "Ele me enfraquece", //5
            "O passado pode ser apagado", //6
            "Nunca", //7
            "Sim!?", //8
            "Sim!?", //9
            "N�o", //10
        };

        pontuacao = 50;

        //Exibe a primeira linha do dialogo
        ShowDialogueLine();

    }

    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            dialogueYesButton.text = dialogueYesOption[currentLine];
            dialogueNoButton.text = dialogueNoOption[currentLine];

            ShuffleButtonPositions();

            ShowOptions();
        }
        else
        {
            EndDialogue();
        }
    }

    void ShuffleButtonPositions()
    {
        // Obtenha os bot�es
        GameObject positiveButton = GameObject.Find("Btn Positive");
        GameObject negativeButton = GameObject.Find("Btn Negative");

        RectTransform positiveButtonRect = positiveButton.GetComponent<RectTransform>();
        RectTransform negativeButtonRect = negativeButton.GetComponent<RectTransform>();

        // Troca aleat�ria
        if (Random.Range(0, 2) == 0)
        {
            Vector3 tempPosition = positiveButtonRect.anchoredPosition;
            positiveButtonRect.anchoredPosition = negativeButtonRect.anchoredPosition;
            negativeButtonRect.anchoredPosition = tempPosition;
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
                //dialogueYesButton.text = dialogueYesOption[0];
                //dialogueNoButton.text = dialogueNoOption[0];
                break;

            case 7: //Quando o jogador pergunta sobre os dragoes;
                imagem1.gameObject.SetActive(false);
                imagem2.gameObject.SetActive(true);
                break;

        }
    }

    void EndDialogue()
    {
        dialogueText.text = "Fim das perguntas";
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
            case 5: //Opcao inicial saber mais
                EndDialogue();
                break;

            case 10:
                EndDialogue();
                break;

            default:
                currentLine += 1;
                pontuacao += 10;
                break;
        }

        //dialogueOptions[1].SetActive(false);

        //currentLine++;
    }

    void HandleNoOption()
    {
        switch (currentLine)
        {
            case 5:
                currentLine += 1;
                pontuacao -= 10;
                break;

            case 10:
                currentLine += 1;
                pontuacao -= 10;
                break;

            default:
                currentLine += 1;
                pontuacao -= 10;
                break;
        }

        //currentLine = 16; //Finaliza o dialogo e diz adeus
    }


    // Update is called once per frame
    void Update()
    {
        txtpontuacao.text = "Pontuacao: " + pontuacao.ToString();
        if (pontuacao > 150)
            pontuacao = 150;
    }

    
}
