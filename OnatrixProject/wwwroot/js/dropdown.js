document.addEventListener('click', (e) => {
    const trigger = e.target.closest('[data-mobile-trigger]');
    if (!trigger) return;

    const menu = document.getElementById('mobile-nav');
    const isHidden = menu.classList.contains('hidden');
    
    menu.classList.toggle('hidden', !isHidden);
    trigger.setAttribute('aria-expanded', isHidden ? 'true' : 'false');
});