// efeito de aparecer ao scroll
function onScrollReveal() {
    const cards = document.querySelectorAll('.card');
    const trigger = window.innerHeight * 0.85;
    cards.forEach(c => {
        const top = c.getBoundingClientRect().top;
        if (top < trigger) c.classList.add('visible');
    });
}
window.addEventListener('load', onScrollReveal);
window.addEventListener('scroll', onScrollReveal);

// envio do form via fetch
const form = document.getElementById('contactForm');
if (form) {
    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        const data = new FormData(form);
        const status = document.getElementById('formStatus');
        status.textContent = 'Enviando...';
        try {
            const res = await fetch(form.action, { method: 'POST', body: data });
            if (res.ok) {
                status.textContent = 'Mensagem enviada! Obrigado.';
                form.reset();
            } else {
                status.textContent = 'Erro ao enviar. Tente novamente.';
            }
        } catch (err) {
            status.textContent = 'Erro na conexão.';
        }
    });
}
