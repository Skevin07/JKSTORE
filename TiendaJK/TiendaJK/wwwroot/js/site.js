// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

fetch('/header.html') // Ruta correcta desde la raíz del servidor web
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.text();
    })
    .then(html => {
        document.getElementById('header-container').innerHTML = html;
    })
    .catch(error => console.error('Error al cargar el archivo HTML:', error));


const sr = ScrollReveal({
    distance: '10px',
    duration: '2400',
    reset: true
});

sr.reveal('.contenido-texto', { delay: 250, origin: 'top' });
sr.reveal('.contenido-img', { delay: 450, origin: 'bottom' });



/*------------------------------------TODO SOBRE EL DASHBOARD-----------------------*/


