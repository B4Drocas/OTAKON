// ================== MENU CUSTOM OTAKON ==================
function toggleOtakonMenu() {
  const menu = document.getElementById('otakonMenu');
  const overlay = document.getElementById('menuOverlay');
  const toggle = document.getElementById('menuToggle');

  menu.classList.toggle('active');
  overlay.classList.toggle('active');
  toggle.classList.toggle('active');
}

function closeOtakonMenu() {
  const menu = document.getElementById('otakonMenu');
  const overlay = document.getElementById('menuOverlay');
  const toggle = document.getElementById('menuToggle');

  menu.classList.remove('active');
  overlay.classList.remove('active');
  toggle.classList.remove('active');
}

function toggleUserMenu(e) {
  e.preventDefault();
  const submenu = document.getElementById('userSubmenu');
  submenu.classList.toggle('active');
}

// ================== BOTÃO SCROLL TO TOP ==================
window.addEventListener('scroll', () => {
  const scrollToTopBtn = document.getElementById('scrollToTopBtn');

  if (!scrollToTopBtn) return;

  if (window.scrollY > 300) {
    scrollToTopBtn.classList.add('show');
  } else {
    scrollToTopBtn.classList.remove('show');
  }
});

function scrollToTop() {
  window.scrollTo({
    top: 0,
    behavior: 'smooth'
  });
}

// Criar botão se não existir
document.addEventListener('DOMContentLoaded', () => {
  if (!document.getElementById('scrollToTopBtn')) {
    const btn = document.createElement('button');
    btn.id = 'scrollToTopBtn';
    btn.innerHTML = '↑';
    btn.onclick = scrollToTop;
    btn.title = 'Voltar ao Topo';
    document.body.appendChild(btn);
  }
});