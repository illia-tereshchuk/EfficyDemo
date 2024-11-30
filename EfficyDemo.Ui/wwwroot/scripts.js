async function fetchEmployees() {
    // Adjust the URL to match your API endpoint
    const response = await fetch('https://localhost:5001/api/employees'); 
    const employees = await response.json();
    const tableBody = document.getElementById('employeesTable').getElementsByTagName('tbody')[0];

    employees.forEach(employee => {
        const row = tableBody.insertRow();
        const nameCell = row.insertCell(0);
        const teamCell = row.insertCell(1);
        const countersCell = row.insertCell(2);

        nameCell.textContent = employee.name;
        teamCell.textContent = employee.team.name;
        countersCell.innerHTML = employee.counters.map(counter => `<li>${counter.value}</li>`).join('');
    });
}

document.addEventListener('DOMContentLoaded', fetchEmployees);
