const validateField = (field) => {
    let errorSpan = document.querySelector(`span[data-valmsg-for='${field.name}']`)
    if (!errorSpan)
        return;

    let errorMessage = "";
    let value = field.value.trim();

    if (field.hasAttribute("data-val-required") && value === "")
        errorMessage = field.getAttribute("data-val-required");

    if (errorMessage !== "") {
        errorSpan.textContent = errorMessage;
        errorSpan.classList.remove("field-validation-valid");
        errorSpan.classList.add("field-validation-error");

        field.classList.remove("input-valid");
        field.classList.add("input-error");
    } else {
        errorSpan.textContent = "";
        errorSpan.classList.remove("field-validation-error");
        errorSpan.classList.add("field-validation-valid");

        field.classList.remove("input-error");
        field.classList.add("input-valid");
    }
};

document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");

    if (!form)
        return;

    const fields = form.querySelectorAll("input[data-val='true']")

    fields.forEach(field => {
        field.addEventListener("input", function () {
            validateField(field);
        });
    });
});