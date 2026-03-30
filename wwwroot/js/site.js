// ============================================================
// OTAKON - Site JavaScript
// ============================================================

// Menu Hamburger
function toggleOtakonMenu() {
    const menu = document.getElementById('otakonMenu');
    menu.classList.toggle('active');
}

function closeOtakonMenu() {
    const menu = document.getElementById('otakonMenu');
    menu.classList.remove('active');
}

// Fechar menu ao clicar fora
document.addEventListener('click', function(event) {
    const menu = document.getElementById('otakonMenu');
    const toggle = document.getElementById('menuToggle');
    
    if (!menu.contains(event.target) && !toggle.contains(event.target)) {
        closeOtakonMenu();
    }
});

// Fechar menu ao pressionar ESC
document.addEventListener('keydown', function(event) {
    if (event.key === 'Escape') {
        closeOtakonMenu();
    }
});

// Dropdown de Idioma
function toggleLanguageDropdown() {
    const dropdown = document.querySelector('.otakon-language-dropdown-menu');
    dropdown.classList.toggle('active');
}

// Fechar dropdown ao clicar fora
document.addEventListener('click', function(event) {
    const dropdown = document.querySelector('.otakon-language-dropdown');
    const btn = document.querySelector('.otakon-language-btn');
    
    if (!dropdown.contains(event.target) && !btn.contains(event.target)) {
        document.querySelector('.otakon-language-dropdown-menu').classList.remove('active');
    }
});

// Definir Idioma
function setLanguage(lang) {
    localStorage.setItem('language', lang);
    location.reload();
}

// Menu de Usuário (se aplicável)
function toggleUserMenu(event) {
    event.preventDefault();
    const submenu = document.getElementById('userSubmenu');
    if (submenu) {
        submenu.classList.toggle('active');
    }
}

// Smooth Scroll para links internos
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function(e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
        }
    });
});

// Dark Mode Detection (opcional)
if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
    document.documentElement.setAttribute('data-theme', 'dark');
}

// Detectar mudanças de tema do SO
window.matchMedia('(prefers-color-scheme: dark)').addListener(e => {
    document.documentElement.setAttribute('data-theme', e.matches ? 'dark' : 'light');
});

console.log('OTAKON Site Loaded ✨');
// Force Light Theme
document.addEventListener('DOMContentLoaded', function() {
    document.documentElement.setAttribute('data-theme', 'light');
    document.documentElement.style.margin = '0';
    document.documentElement.style.padding = '0';
    document.body.style.backgroundColor = '#ffffff';
    document.body.style.color = '#1a1a1a';
    document.body.style.margin = '0';
    document.body.style.padding = '0';
});

function toggleOtakonMenu() {
    const menu = document.getElementById('otakonMenu');
    if (menu) menu.classList.toggle('active');
}

function closeOtakonMenu() {
    const menu = document.getElementById('otakonMenu');
    if (menu) menu.classList.remove('active');
}

document.addEventListener('click', function(event) {
    const menu = document.getElementById('otakonMenu');
    const toggle = document.getElementById('menuToggle');
    if (menu && toggle && !menu.contains(event.target) && !toggle.contains(event.target)) {
        closeOtakonMenu();
    }
});

document.addEventListener('keydown', function(event) {
    if (event.key === 'Escape') closeOtakonMenu();
});

function toggleLanguageDropdown() {
    const dropdown = document.querySelector('.otakon-language-dropdown-menu');
    if (dropdown) dropdown.classList.toggle('active');
}

document.addEventListener('click', function(event) {
    const dropdown = document.querySelector('.otakon-language-dropdown');
    const btn = document.querySelector('.otakon-language-btn');
    if (dropdown && btn && !dropdown.contains(event.target) && !btn.contains(event.target)) {
        const menu = document.querySelector('.otakon-language-dropdown-menu');
        if (menu) menu.classList.remove('active');
    }
});

function setLanguage(lang) {
    localStorage.setItem('language', lang);
    location.reload();
}

function toggleUserMenu(event) {
    event.preventDefault();
    const submenu = document.getElementById('userSubmenu');
    if (submenu) submenu.classList.toggle('active');
}

console.log('✨ OTAKON Loaded');
