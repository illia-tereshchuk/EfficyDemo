async function deleteCounterHandler() {
    const selectTeams = document.getElementById('selectTeams2');
    const selectEmployees = document.getElementById('selectEmployees2');
    const selectCounters = document.getElementById('selectCounters2');
    const inputIncreaseBy = document.getElementById('inputIncreaseBy2');
    const buttonIncreaseCounter = document.getElementById('buttonIncreaseCounter2');
   
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
    async function onIncreaseCounter() {
        const counterId = selectCounters.value;
        const value = inputIncreaseBy.value;
        const response = await fetch(`${apiRoot}/Counters/increaseCounter?counterId=${counterId}&value=${value}`, {
            method: 'PATCH',
            headers: { 'Content-Type': 'application/json' }
        });
        if (response.ok) {
            alert('Counter increased successfully');
        } else {
            const error = await response.json();
            alert(`Failed to increase counter: ${error.message}`);
        }
    }


    buttonIncreaseCounter.addEventListener('click', onIncreaseCounter);
}

document.addEventListener('DOMContentLoaded', deleteCounterHandler);
