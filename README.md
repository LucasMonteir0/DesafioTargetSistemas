# 🎯 Desafio Técnico | Desenvolvedor de Sistemas Jr — Target Sistemas

Este repositório contém uma **Console Application em C#** desenvolvida para atender aos requisitos do desafio técnico proposto para a vaga de **Desenvolvedor de Sistemas Júnior** na **Target Sistemas**.  
O projeto demonstra domínio em **lógica de programação**, **manipulação de dados**, e **Orientação a Objetos (OO)**.

---

## 🚀 Sobre o Projeto

O sistema apresenta um **menu interativo** para execução de **três desafios independentes**, cada um implementado em classes separadas:

- `Desafio1Comissao.cs`
- `Desafio2Estoque.cs`
- `Desafio3Juros.cs`

Essa separação garante **modularidade**, **organização** e **facilidade de manutenção**.

---

## 🧠 Habilidades Demonstradas

### ✔️ Manipulação de Arquivos e JSON
- Leitura e desserialização de `dados.json` via **System.Text.Json**
- Tratamento robusto de exceções (ex.: `FileNotFoundException`)
- Ajustes de cultura para leitura correta de valores decimais

### ✔️ Lógica de Negócios
- Regras condicionais estruturadas (ex.: cálculo de comissão)
- Implementação de lógica financeira (juros compostos)

### ✔️ Orientação a Objetos
- Modelagem com classes como `Produto` e `Movimentacao`
- Uso de **enums** (ex.: `TipoMovimentacao`)
- Organização coesa e clara do domínio

### ✔️ Estruturas de Controle e Coleções
- Uso eficiente de **Dictionary**, **LINQ** e métodos de extensão
- Agregação e filtragem de dados de forma performática

---

## ⚙️ Como Funciona o Projeto

O arquivo `Program.cs` exibe um **menu interativo no console**, permitindo escolher qual desafio executar.

---

# 🧩 Desafios Implementados

---

## 🟦 Desafio 1 — Calculadora de Comissões de Vendas

**Objetivo:**  
Calcular a **comissão total** de cada vendedor com base nos registros do arquivo `dados.json`.

### 📌 Regras de Negócio (Comissão)
| Faixa de Venda        | Comissão        |
|-----------------------|-----------------|
|      < R$ 100,00      |     **0%**      |
| R$ 100,00 — R$ 499,99 |     **1%**      |
|      ≥ R$ 500,00      |     **5%**      |

**Saída:**  
Relatório exibindo o total de comissão por vendedor.

---

## 🟩 Desafio 2 — Sistema de Movimentação de Estoque

**Objetivo:**  
Simular um sistema de **entrada e saída** de produtos, incluindo controle de saldo e histórico.

### 📌 Como funciona:
- Estrutura baseada em `Movimentacao` + enum `TipoMovimentacao`
- Histórico completo registrando cada operação
- Exibição do estoque atual e todas as movimentações realizadas

---

## 🟥 Desafio 3 — Calculadora de Juros por Atraso

**Objetivo:**  
Calcular o **montante total** de um débito vencido aplicando **juros compostos de 2,5% ao dia**.

### 📌 Regra de Negócio (Juros)
A taxa diária é de **2,5% (0,025)** ao dia.

### 📘 Fórmula Utilizada

\[
M = C \cdot (1 + r)^n
\]

Onde:  
- **M** = Montante  
- **C** = Valor original  
- **r** = Taxa diária  
- **n** = Número de dias em atraso  

---

Se quiser, posso ajudar você a estilizar também **badges**, **seções adicionais**, **prints**, **instruções de execução**, ou criar uma **versão em inglês**.
