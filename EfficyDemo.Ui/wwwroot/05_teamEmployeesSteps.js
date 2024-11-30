async function teamEmployeesStepsHandler() {
    const selectTeams = document.getElementById('selectTeams5');
    const tableBody = document.getElementById('tableEmployees5').getElementsByTagName('tbody')[0];

    // Load employees on team select
    async function onTeamSelectChange() {
        tableBody.innerHTML = '';
        const teamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Teams/${teamId}/employees`);
        const employees = await response.json(); 
        employees.forEach(employee => { // { name, totalSteps }
            const row = tableBody.insertRow();
            const nameCell = row.insertCell(0);
            const totalStepsCell = row.insertCell(1);
            nameCell.textContent = employee.name;
            totalStepsCell.textContent = employee.totalSteps;
        });
    }
    selectTeams.addEventListener('change', onTeamSelectChange);

    // Load teams
    const response = await fetch(`${apiRoot}/Teams/all`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');
}
document.addEventListener('DOMContentLoaded', teamEmployeesStepsHandler);