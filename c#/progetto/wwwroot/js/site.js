// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleForms() {
    const loginForm = document.getElementById('loginForm');
    const registerForm = document.getElementById('registerForm');

    if (loginForm.style.display === 'none') {
        loginForm.style.display = 'block';
        registerForm.style.display = 'none';
    } else {
        loginForm.style.display = 'none';
        registerForm.style.display = 'block';
    }
}

document.getElementById('registerFormSubmit').addEventListener('submit', function (event) {
    event.preventDefault();
    handleRegister(event);
});

function handleRegister(event) {
    const form = event.target;
    const formData = new FormData(form);

    fetch('nutrify_registrazione.php', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert("Registrazione effettuata con successo!");
                toggleForms();
            } else {
                alert("Errore durante la registrazione: " + data.message);
            }
        })
        .catch(error => {
            console.error('Errore:', error);
            alert("Errore di rete.");
        });
}

function handleLogin(event) {
    event.preventDefault();
    alert("Login effettuato con successo!");
    window.location.href = "home.html";
}

document.getElementById('registerForm').style.display = 'none';
