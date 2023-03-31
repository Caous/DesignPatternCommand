# Designer Pattern Command / Padrão de projeto Comandos

Projeto com finalidade em mostrar o padrão de projeto Mediator com implementação

![Mediator](https://refactoring.guru/images/patterns/content/mediator/mediator.png?id=0264bd857a231b6ea2d0c537c092e698)


### <h2>Fala Dev, seja muito bem-vindo
   Está POC é para mostrar como podemos implementar o Design Pattern Mediator/Padrão de Projeto Mediador em diversos projetos com adaptação para o cenário que você precisar e contiver códigos legados ou evoluções no estilo MVP, também te explico o que é o Design Pattern Mediator/Padrão de Projeto Mediador e como usar em diversas situações. Espero que encontre o que procura <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30"> 
</em></p></h5>
  
  </br>
  


<img align="right" src="https://methodpoet.com/wp-content/uploads/2022/06/mediator-pattern-solution.png" width="300" height="300"/>


</br></br>

### <h2>Mediator <a href="https://refactoring.guru/pt-br/design-patterns/mediator" target="_blank"><img alt="Mediator" src="https://img.shields.io/badge/Mediator-blue?style=flat&logo=google-chrome"></a>

 <a href="https://refactoring.guru/pt-br/design-patterns/mediator" target="_blank">Design Pattern Mediator ou Padrão de Projeto Mediador </a> é um padrão de projeto para <b>resolver um problema que já foi encontrado por outras pessoas</b>, sendo assim por este problema ter se repetido diversas vezes, criaram-se um padrão de solução ou como costumamos dizer Padrão de Projeto / Design Pattern para resolver este problema.
 
Esse padrão de projeto pode ser utilizado <b>INDIFERENTE DA LINGUAGEM DE PROGRAMAÇÃO</b>, ou seja, pode ser aplicado em qualquer lugar. Mas fica um <b>Ponto de Atenção</b> para vocês, só implementem realmente se fizer sentido.
 
Design Pattern Mediator tem como objetivo centralizar códigos que precisam de complemento de outros, ou seja, uma ação quando solicitada, precisar processar outro código/classe, ao invés de termos uma classe chamando a outra, temos um centralizador. Desta forma pense que o Mediator é uma forma de arbitro pronto para orquestra o jogo da forma que precisa, ele é responsável por cada ação que acontece, ou seja, se uma falta for cometida ele dá um cartão, advertência, se alguém for ser trocado durante o jogo, ele também irá orquestrar e chamar os responsáveis para tal ação acontecer com sucesso.

Sendo assim Mediator utiliza 3 Pilares:

<b>Mediator</b> A interface do Mediador declara métodos de comunicação com os componentes, os quais geralmente incluem apenas um método de notificação.
   
<b>Concrete</b> Os Mediadores Concretos encapsulam as relações entre vários componentes. Os mediadores concretos quase sempre mantém referências de todos os componentes os quais gerenciam e, algumas vezes, até gerenciam o ciclo de vida deles.
   
<b>Componentes</b> Os Componentes são várias classes que contém alguma lógica de negócio.

Legal né? Mas agora a pergunta é como posso usar o Mediator? Abaixo dou um exemplo de caso de uso.

</br></br>

### <h2>[Cenário de Uso]
Vamos imaginar o seguinte cenário, você tem uma oficina onde sua oficina tem o serviço de <b>ordem de serviço </b>, mas dentro da sua oficina você tem diversos serviços (catálogo) e cada serviço que chega, você tem uma regra de negócio para ele, validar por exemplo se está faltando peça, se precisa de reposição etc... Como você poderia centralizar a chamada de cada serviço sem que na sua tela (Windows Form/Asp.net Web) do seu projeto implemente todas as classes fazendo uma mistura e acessos diretos que talvez nem deveria ocorrer devido a arquitetura do projeto? Esse é o objetivo do Mediator, saber quem será chamado.

### <h2> Criação de Classes

Vamos criar a interface que contém os métodos necessários para chamada dos componentes.
```C#
   public interface IMediator
   {
    void Notify(object sender, EServico servicos);
   }
```

Próxima etapa é criarmos a classe context que terá o método de notify e conhece todas classes necessárias.
```C#

///Classe que implementa o IMediator
 public class ConcreteMediator : IMediator
   {
    private readonly EsteticaServico _estetica;
    private readonly FreioServico _freio;
    private readonly OleoServico _oleo;

    public ConcreteMediator(EsteticaServico estetica, FreioServico freio, OleoServico oleo)
    {
        _estetica = estetica;
        _estetica.SetMediator(this);
        _freio = freio;
        _freio.SetMediator(this);
        _oleo = oleo;
        _oleo.SetMediator(this);
    }
    public void Notify(object sender, EServico servicos)
    {

        switch (servicos)
        {
            case EServico.Freios:
                _freio.CriarOrdemServico();
                break;
            case EServico.Oleo:
                _oleo.CriarOrdemServico();
                break;
            case EServico.Estetica:
                _estetica.CriarOrdemServico();
                break;
            default:
                break;
        }


    }
   }
```
</br>

Agora vamos criar nossa classes de negócio.
```C#
   public class EsteticaServico : OrdemServicoBase
   {
      public EsteticaServico(string servico, IMediator mediator = null) : base(servico, mediator)
      {
      }

      public void ServicoEfetuado()
      {
           Console.WriteLine($"Servico efetuado as {DateTime.Now} {base.CriarOrdemServico()}");
           this._mediator.Notify(this, Enumeradores.EServico.Estetica);
      }

   }
   
   public class FreioServico : OrdemServicoBase
   {
      public FreioServico(string servico, IMediator mediator = null) : base(servico, mediator)
      {
      }

      public void ServicoEfetuado()
      {
        Console.WriteLine($"Servico efetuado as {DateTime.Now} {CriarOrdemServico()}");
        this._mediator.Notify(this, EServico.Estetica);
      }
   }

   public class OleoServico : OrdemServicoBase
   {
      public OleoServico(string servico, IMediator mediator = null) : base(servico, mediator)
      {
      }
      public void ServicoEfetuado()
      {
        Console.WriteLine($"Servico efetuado as {DateTime.Now} {CriarOrdemServico()}");
        this._mediator.Notify(this, EServico.Estetica);
      }
   }
```

E por ultimo a implementação.

```C#
using MediatorDesignPattern.Mediator;
using MediatorDesignPattern.Servicos;

EsteticaServico esteticaServico = new EsteticaServico("Vidrificação");
FreioServico freioServico = new FreioServico("Troca pastilho de freio");
OleoServico oleoServico = new OleoServico("Troca de oléo");

new ConcreteMediator(esteticaServico, freioServico, oleoServico);

esteticaServico.ServicoEfetuado();
freioServico.ServicoEfetuado();
oleoServico.ServicoEfetuado();
```


### <h5> [IDE Utilizada]</h5>
![VisualStudio](https://img.shields.io/badge/Visual_Studio_2019-000000?style=for-the-badge&logo=visual%20studio&logoColor=purple)

### <h5> [Linguagem Programação Utilizada]</h5>
![C#](https://img.shields.io/badge/C%23-000000?style=for-the-badge&logo=c-sharp&logoColor=purple)

### <h5> [Versionamento de projeto] </h5>
![Github](http://img.shields.io/badge/-Github-000000?style=for-the-badge&logo=Github&logoColor=green)

</br></br></br></br>


<p align="center">
  <i>🤝🏻 Vamos nos conectar!</i>

  <p align="center">
    <a href="https://www.linkedin.com/in/gusta-nascimento/" alt="Linkedin"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/174857.png" height="30" width="30"></a>
    <a href="https://www.instagram.com/gusta.nascimento/" alt="Instagram"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/instagram-logo-png-transparent-background-hd-3.png" height="30" width="30"></a>
    <a href="mailto:caous.g@gmail.com" alt="E-mail"><img src="https://github.com/nitish-awasthi/nitish-awasthi/blob/master/gmail-512.webp" height="30" width="30"></a>   
  </p>
