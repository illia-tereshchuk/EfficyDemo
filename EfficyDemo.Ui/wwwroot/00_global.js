const apiRoot = "http://localhost:37743/api";
function populateSelect(selectElement, items, valueKey, textKey) {
    selectElement.innerHTML = '';
    items.forEach(item => {
        const option = document.createElement('option');
        option.value = item[valueKey];
        option.textContent = item[textKey];
        selectElement.appendChild(option);
    });
    if (items.length > 0) {
        selectElement.dispatchEvent(new Event('change'));
    }
}