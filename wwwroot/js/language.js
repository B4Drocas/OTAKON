// Sistema de Idioma OTAKON
let translations = {};
let currentLanguage = localStorage.getItem('otakon-language') || 'pt';

// Carregar traduções
async function loadTranslations() {
  try {
    const response = await fetch('/js/translations.json');
    translations = await response.json();
    setLanguage(currentLanguage);
  } catch (error) {
    console.error('Erro ao carregar traduções:', error);
  }
}

// Obter tradução
function t(key) {
  const keys = key.split('.');
  let value = translations[currentLanguage];

  for (let k of keys) {
    value = value?.[k];
  }

  return value || key;
}

// Mudar idioma
function setLanguage(lang) {
  if (!translations[lang]) return;

  currentLanguage = lang;
  localStorage.setItem('otakon-language', lang);

  // Atualizar UI
  updateLanguageUI();

  // Fechar dropdown se aberto
  const dropdown = document.querySelector('.otakon-language-dropdown');
  if (dropdown) {
    dropdown.classList.remove('active');
  }
}

// Obter idioma atual
function getLanguage() {
  return currentLanguage;
}

// Toggle dropdown de idiomas
function toggleLanguageDropdown() {
  const dropdown = document.querySelector('.otakon-language-dropdown');
  if (dropdown) {
    dropdown.classList.toggle('active');
  }
}

// Fechar dropdown ao clicar fora
document.addEventListener('click', function(event) {
  const dropdown = document.querySelector('.otakon-language-dropdown');
  const btn = document.querySelector('.otakon-language-btn');

  if (dropdown && !dropdown.contains(event.target) && btn && !btn.contains(event.target)) {
    dropdown.classList.remove('active');
  }
});

// Atualizar interface com novos textos
function updateLanguageUI() {
  // Atualizar elementos com atributo data-i18n
  document.querySelectorAll('[data-i18n]').forEach(element => {
    const key = element.getAttribute('data-i18n');
    element.textContent = t(key);
  });

  // Atualizar atributos com data-i18n-attr
  document.querySelectorAll('[data-i18n-attr]').forEach(element => {
    const attr = element.getAttribute('data-i18n-attr');
    const key = element.getAttribute('data-i18n-key');
    if (attr && key) {
      element.setAttribute(attr, t(key));
    }
  });

  // Atualizar aria-label
  document.querySelectorAll('[data-i18n-aria]').forEach(element => {
    const key = element.getAttribute('data-i18n-aria');
    element.setAttribute('aria-label', t(key));
  });

  // Atualizar atributo title
  document.querySelectorAll('[data-i18n-title]').forEach(element => {
    const key = element.getAttribute('data-i18n-title');
    element.setAttribute('title', t(key));
  });

  // Atualizar botões de idioma
  document.querySelectorAll('.otakon-lang-btn').forEach(btn => {
    btn.classList.remove('active');
  });

  const activeBtn = document.getElementById('lang' + currentLanguage.toUpperCase());
  if (activeBtn) {
    activeBtn.classList.add('active');
  }

  // Atualizar atributo lang da página
  document.documentElement.lang = currentLanguage;

  // Dispor evento de mudança de idioma
  document.dispatchEvent(new CustomEvent('languageChanged', { detail: { language: currentLanguage } }));
}

// Ao carregar a página
document.addEventListener('DOMContentLoaded', loadTranslations);

