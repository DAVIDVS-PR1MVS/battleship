# battleship
Versão do jogo clássico de Batalha Naval desenvolvida em C#, aplicando conceitos estruturados de Orientação a Objetos em ambiente de console. Projeto arquitetado para futura expansão gráfica (GUI).

Batalha Naval - Console Application (C# Nativo)

Este projeto consiste em uma implementação completa e robusta do clássico jogo de Batalha Naval, desenvolvida inteiramente em C# nativo, sem a utilização de frameworks ou gerenciadores de dependências adicionais. O foco principal do desenvolvimento foi a aplicação prática dos pilares da Programação Orientada a Objetos (POO) e a manipulação eficiente de estruturas de dados bidimensionais diretamente no ambiente de console.
O software funciona através de um motor lógico centralizado que gerencia o estado do jogo independentemente da interface de exibição. Essa decisão de arquitetura garante que o núcleo das regras de negócio — como o posicionamento dos navios, a validação de disparos e a alteração dos estados da matriz — permaneça isolado, facilitando a portabilidade e a manutenção do código.

Perspectivas Futuras

O projeto foi planejado em etapas bem definidas. Com a conclusão do motor lógico bruto e da validação de matrizes via terminal, a próxima fase consiste no desenvolvimento de uma interface gráfica nativa.
Devido à separação estrita de responsabilidades implementada na arquitetura atual, as classes que controlam as regras do jogo e o posicionamento dos navios serão integralmente reaproveitadas, exigindo apenas a substituição da camada de apresentação do console por elementos visuais interativos.
