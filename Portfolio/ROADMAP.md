Roadmap - ajustes de UI
=======================

Novas tarefas solicitadas pelo cliente (prioridade alta):

- Padding entre a borda da `main` e o texto
  - Implementação: adicionar padding horizontal na `.main` e ajustar `container` se necessário.
  - Critério de sucesso: texto não encostando na borda em qualquer viewport.

- Centralizar os projetos
  - Implementação: usar `justify-items: center` na grade `projects-grid` e `text-align: center` nos cards.
  - Critério de sucesso: cards alinhados ao centro dentro da grid.

- Colocar a bio mais para a esquerda
  - Implementação: usar `justify-content: space-between` no `.hero-content` para empurrar a bio à esquerda e a foto à direita.
  - Critério de sucesso: bio ancorada à esquerda da seção hero em telas grandes.

- Aumentar a fonte dos textos
  - Implementação: elevar `body` font-size e ajustar `h1/h2` para boa hierarquia visual.
  - Critério de sucesso: legibilidade melhor sem quebra de layout.

- Botar cores
  - Implementação: usar variáveis CSS (`--accent`, `--muted`) para colorir títulos, links e pequenos detalhes.
  - Critério de sucesso: paleta aplicada consistente.

- Diminuir form para deixar mais achatado
  - Implementação: reduzir `padding` e `height` de inputs/textarea e ajustar `border-radius`.
  - Critério de sucesso: formulário com visual mais compacto, mantendo usabilidade.

Notas de implementação
- Alterações aplicadas diretamente em `wwwroot/css/site.css`.
- Testes manuais: validar em telas desktop e mobile.

Próximos passos
- Ajustar textos com sample content final e substituir imagens (pasta `wwwroot/assets/images`).
- Pipeline de build e deploy quando aprovar visual.

Nova tarefa solicitada: imagens dos projetos com hover-swap
-------------------------------------------------------

- Descriçãoo: cada projeto terá 2 imagens (ex.: `proj1-1.jpg` e `proj1-2.jpg`) exibidas em um mesmo card; ao passar o mouse, a imagem 1 esmaece e a imagem 2 aparece com transição suave.

- Estrutura de arquivos:
  - Salvar imagens em `wwwroot/assets/images/`.
  - Nome sugerido: `<project-name>-1.jpg` e `<project-name>-2.jpg` (ou `.webp`).

- Implementação (resumo):
  - HTML: dentro do `.project-card` inserir duas `img` empilhadas (uma com classe `.img-front` outra `.img-back`).
  - CSS: posicionamento absoluto dentro de um container relativo; transição de opacidade no hover para trocar as imagens.
  - Mobile: fallback para mostrar apenas a imagem principal (sem hover) ou usar toque para alternar via JS.

- Performance e acessibilidade:
  - Recomendação: gerar WebP e `srcset` (variações de tamanho) para economizar banda.
  - Lazy-load (`loading="lazy"`) para imagens fora da viewport.
  - `alt` descritivo em cada imagem.

- Pequeno exemplo de fluxo de trabalho:
  1. Você envia as imagens (2 por projeto) para `wwwroot/assets/images/`.
  2. Eu atualizo `Pages/Index.cshtml` para incluir as `img` nos cards e adiciono o CSS para hover-swap.
  3. Testamos em desktop e mobile; aplico fallback por toque se desejar.

- Critério de sucesso: cada card dos projetos troca entre duas imagens com transição suave no hover, imagens otimizadas e sem impacto perceptível na performance.
