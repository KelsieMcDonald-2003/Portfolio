export function navbar() {
    fetch('./navbar.html')
        .then(response => response.text())
        .then(html => {
            const navbarContainer = document.querySelector('#navbar');
            navbarContainer.innerHTML = html;
        })
        .catch(err => {
            console.error('Error:', err);
        });
}

