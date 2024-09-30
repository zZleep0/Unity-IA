# Unity-IA
Material from Unity AI classes.

# Dicas para Melhorar o Layout dos Scripts na Unity

## Navegação e Visualização

- **Maximizar Janelas**: Use o atalho `Shift + Espaço` para maximizar janelas na Unity.
- **Alinhar a Câmera**: Para alinhar a câmera com a visão atual do Game, selecione a câmera e use o atalho `Ctrl + Shift + F`.
- **Foco em Objetos**: Clique no objeto e pressione `F` para focar nele. Use `Shift + F` para que a câmera siga o objeto.

## Organização de Objetos na Cena

- **Usar Layers**: Separe objetos usando layers para facilitar a visualização e ocultação quando necessário.
  
## Dicas para o Inspector

- **Criar Campo do Tipo Slider**: Para transformar um campo numérico em um slider, use o exemplo: `[Range(0.1f, 5.0f)]`.
- **Adicionar Espaço entre Variáveis Públicas**: Use `[Space]` após a declaração da variável para adicionar espaço.
- **Colocar Headers**: Use `[Header("Nome do Header")]` para separar variáveis no Inspector.
- **Esconder Variáveis Públicas**: Utilize `[HideInInspector]` após a variável para ocultá-la.
- **Editar Variáveis Privadas no Inspector**: Coloque `[SerializeField]` antes da declaração da variável.
- **Adicionar Tooltips**: Use `[Tooltip("Exemplo de mensagem")]` para adicionar uma descrição quando a variável for interagida.
- **Cálculos em Variáveis Numéricas**: É possível realizar cálculos diretamente nas variáveis numéricas no Inspector.

## Dicas de Código

- **Auto Complete**: Use a tecla `Tab` duas vezes para auto completar comandos como `if`, `switch`, `for`, etc.
- **Organização de Código**: Utilize `#region Title` e `#endregion` para organizar seu código em blocos.
- **Destruir Objetos**: Para destruir um objeto na cena, use:
  ```csharp
  Destroy(gameObject);
  ```
  Para destruir após um tempo (ex: 5 segundos):
  ```csharp
  Destroy(gameObject, 5.0f);
  ```

- **Comparar Tags**: Para comparar tags na Unity, use:
  ```csharp
  variavel.CompareTag("nomeTag");
  ```
- **Adicionar Opção no Inspector**: Use `[ContextMenu("NomeQueQuiser")]` para criar uma opção que aciona uma função no Inspector.
- **Função Static no Menu**: Para que uma função estática apareça no menu do Inspector, utilize:
  ```csharp
  using UnityEditor;
  
  [MenuItem("nomeMenu/oqueFaz")]
  ```

## Dicas para a Hierarquia

- **Organização da Hierarquia**: Use objetos vazios como divisores e nomeie-os, por exemplo: `-------------Objetos de Cenário --------`.
- **Expandir/Contrair Elementos**: Use `Alt + Click` no elemento desejado para expandir ou contrair.

## Canvas e Text

- **TextMeshPro**: Importe o TextMeshPro para ter mais opções de configuração de layout de texto.

## Salvando Layouts

- **Salvar Layouts**: Salve o layout que você gosta na opção de layout do menu.

Com essas dicas, você pode otimizar seu fluxo de trabalho e a organização dos seus scripts na Unity!