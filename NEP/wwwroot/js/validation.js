var $j = jQuery.noConflict();


const emailInput = document.getElementById('email');
const nameInput = document.getElementById('name');
emailInput.addEventListener('blur', validateEmail);
nameInput.addEventListener('blur', validateName);
var emailIsValid = false;
var nameIsValid = false;
var formIsValid = false;

// Function to validate the email address
function validateEmail() {

    const email = emailInput.value.trim();
    const emailRegex = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
    if (emailRegex.test(email)) {
        emailInput.classList.remove('error');
        emailIsValid = true;
    } else {
        emailInput.classList.add('error');
        emailIsValid = false;
    }
}

// Function to validate the email address
function validateName() {

    const name = nameInput.value.trim();

    if (name.length > 0) {
        nameInput.classList.remove('error');
        nameIsValid = true;
    } else {
        nameInput.classList.add('error');
        nameIsValid = false;
    }
}

function sendContactForm() {
    //debugger;
    validateEmail();
    validateName();
    formIsValid = emailIsValid && nameIsValid;
    if (formIsValid) {
        jQuery.post('/ContactUs/Index', {
            name: tpj('#name').val(), // Replace with your data parameters
            email: tpj('#email').val(),
            subject: tpj('#subject').val(),
            body: tpj('#body').val()
        }, function (response) {
            // Handle the response from the server
            console.log(response);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            // Handle any errors that occurred during the request
            console.log(textStatus, errorThrown);
        }).always(function () {
            jQuery('#contactform').slideUp("slow").hide();
            jQuery('#contactWrapper').append('<div class="success"><h4>Email Successfully Sent!</h4><br><p>Thank you for using our contact form <strong>' + decodeURIComponent(name) + '</strong>! Your email was successfully sent and we&#39;ll be in touch with you soon.</p></div>');
        });
    }
}