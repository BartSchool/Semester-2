function updateText(checkbox) {
    var textElement = checkbox.parentNode.querySelector('.checkmark-text');
    if (checkbox.checked) {
        textElement.textContent = 'Open';
    } else {
        textElement.textContent = 'Closed';
    }
}