// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
document.body.addEventListener('htmx:configRequest', function(evt) {
    if (evt.detail.verb === 'post') {
        // global
        var token = document.getElementById("global-aft").value;
        evt.detail.parameters['__RequestVerificationToken'] = token;
        console.log(evt);
    }
});