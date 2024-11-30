async function deleteCounterHandler() {
    const selectTeams = document.getElementById('selectTeams7');
    const selectEmployees = document.getElementById('selectEmployees7');
    const selectCounters = document.getElementById('selectCounters7');
    const buttonIncreaseCounter = document.getElementById('buttonDeleteCounter7');

    // Load counters on employee select
    async function onEmployeeSelectChange() {
        const employeeId = selectEmployees.value;
        const response = await fetch(`${apiRoot}/Counters/employee/${employeeId}`);
        const counters = await response.json();
        populateSelect(selectCounters, counters, 'id', 'value');
    }
    selectEmployees.addEventListener('change', onEmployeeSelectChange);

    // Load employees on team select
    async function onTeamSelectChange() {
        const teamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Teams/${teamId}/employees`);
        const employees = await response.json();
        populateSelect(selectEmployees, employees, 'id', 'name');
    }
    selectTeams.addEventListener('change', onTeamSelectChange);

    // Load teams
    const response = await fetch(`${apiRoot}/Teams/getAll`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');

    // Button click handler
    async function onDeleteCounter() {
        const response = await fetch(`${apiRoot}/Counters/deleteCounter?counterId=${selectCounters.value}`, {
            method: 'DELETE'
        });
        if (response.ok) {
            alert('Counter deleted successfully');
            selectCounters.options[selectCounters.selectedIndex].remove();
        } else {
            alert('Failed to deleted counter');
        }
    }
    buttonIncreaseCounter.addEventListener('click', onDeleteCounter);
}

document.addEventListener('DOMContentLoaded', deleteCounterHandler);
