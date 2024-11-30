async function addCounterHandler() {
    const selectTeams = document.getElementById('selectTeams1');
    const selectEmployees = document.getElementById('selectEmployees1');
    const buttonAddCounter = document.getElementById('buttonAddCounter1');

    // Load employees on team select
    async function onTeamSelectChange() {
        const teamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Teams/getEmployees?teamId=${teamId}`);
        const employees = await response.json();
        populateSelect(selectEmployees, employees, 'id', 'name');
    }
    selectTeams.addEventListener('change', onTeamSelectChange);

    // Load teams
    const response = await fetch(`${apiRoot}/Teams/getAll`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');

    // Button click handler
    async function onAddCounter() {
        const value = document.getElementById('inputCounterValue1').value;
        const employeeId = selectEmployees.value;
        const response = await fetch(`${apiRoot}/Counters/addCounter?employeeId=${employeeId}&value=${value}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        });
        if (response.ok) {
            alert('Counter added successfully');
        } else {
            alert('Failed to add counter');
        }
    }
    buttonAddCounter.addEventListener('click', onAddCounter);
}
document.addEventListener('DOMContentLoaded', addCounterHandler);

