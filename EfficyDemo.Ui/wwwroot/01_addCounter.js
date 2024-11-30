async function addCounterHandler() {
    const selectTeams = document.getElementById('selectTeams1');
    const selectEmployees = document.getElementById('selectEmployees1');
    const buttonAddCounter = document.getElementById('buttonAddCounter1');

    // Load employees on team select
    async function onTeamSelectChange() {
        const teamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Teams/${teamId}/employees`);
        const employees = await response.json();
        populateSelect(selectEmployees, employees["employeesSteps"], 'id', 'name');
    }
    selectTeams.addEventListener('change', onTeamSelectChange);

    // Load teams
    const response = await fetch(`${apiRoot}/Teams/all`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');

    // Button click handler
    async function onAddCounter() {
        const data = {
            value: document.getElementById('inputCounterValue1').value,
            employeeId: selectEmployees.value
        };
        const response = await fetch(`${apiRoot}/Counters/add`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if (response.ok) {
            const result = await response.json();
            alert('Counter added successfully');
        } else {
            alert('Failed to add counter');
        }
    }
    buttonAddCounter.addEventListener('click', onAddCounter);
}
document.addEventListener('DOMContentLoaded', addCounterHandler);

