![ES-5](https://github.com/user-attachments/assets/3360a2e6-5e1d-4643-b946-b61e9bef3b49)

# 🥁 CarnaCode 2026 - Desafio 10 - Facade

Oi, eu sou o **Leonardo Malavolti** e este é o espaço onde compartilho minha jornada de aprendizado durante o desafio **CarnaCode 2026**, realizado pelo [balta.io](https://balta.io). 👻  

Aqui você vai encontrar projetos, exercícios e códigos que estou desenvolvendo durante o desafio. O objetivo é colocar a mão na massa, testar ideias e registrar minha evolução no mundo da tecnologia.

---

## 📚 Sobre este desafio

No desafio **Facade**, precisei simplificar um cenário real de e-commerce onde o processo de finalização de pedido dependia de múltiplos subsistemas independentes.

Durante o desenvolvimento, trabalhei conceitos fundamentais como:

- ✅ Boas práticas de arquitetura
- ✅ Código limpo
- ✅ Princípios SOLID
- ✅ Redução de acoplamento
- ✅ Encapsulamento de complexidade

---

## 🚨 Problema

O fluxo de finalização de pedido envolve múltiplos subsistemas:

- 📦 Estoque  
- 💳 Pagamento  
- 🚚 Envio  
- 🎟 Cupons  
- 📧 Notificações  

Cada um possui sua própria interface e sequência de execução.

O código cliente precisava:

- Conhecer todos os subsistemas
- Executar os passos na ordem correta
- Tratar erros e rollback manualmente
- Controlar regras de negócio espalhadas

Isso gerava:

- ❌ Alto acoplamento
- ❌ Código complexo
- ❌ Baixa manutenibilidade
- ❌ Risco de inconsistência

---

## ✅ Solução com o Pattern Facade

O padrão **Facade** foi aplicado para criar uma interface simples e unificada:

```csharp
var facade = new OrderFacade();
facade.ProcessOrder(order);
```

Agora:

- O cliente conhece apenas uma classe
- A complexidade fica encapsulada
- A orquestração é centralizada
- A interface se torna simples e intuitiva

---

## 🎯 Benefícios da Implementação

✔ Redução significativa do acoplamento  
✔ Interface simples e clara  
✔ Complexidade encapsulada  
✔ Melhor organização da lógica de negócio  
✔ Código mais legível  
✔ Facilita manutenção e evolução do sistema  

---

## 🧠 Conceitos reforçados

Durante este desafio, reforcei principalmente:

- Encapsulamento
- Abstração de complexidade
- Separação de responsabilidades
- Arquitetura orientada a serviços
- Organização por camadas

---

## 🏁 Sobre o CarnaCode 2026

O desafio **CarnaCode 2026** consiste em implementar todos os **23 Design Patterns clássicos** em cenários reais.

Ao longo da jornada, os participantes desenvolvem a capacidade de:

- Identificar problemas arquiteturais
- Aplicar padrões de forma correta
- Melhorar escalabilidade e manutenibilidade
- Evoluir a maturidade técnica

---

## 📖 eBook - Fundamentos dos Design Patterns

Minha principal fonte de estudo durante o desafio foi o eBook gratuito:

👉 [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns)

---

## 📌 Veja meu progresso no desafio

🔗 [Incluir aqui o link do repositório central do CarnaCode]

---

🚀 Seguimos para o próximo padrão!
