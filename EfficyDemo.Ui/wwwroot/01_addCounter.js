async function addCounterHandler() {
    // ++ Load teams
    const response = await fetch(apiRoot + '/Teams/all');
    const teams = await response.json();
    const selectTeams = document.getElementById('selectTeams1');
    teams.forEach(team => { // { id, name, totalSteps }
        const option = document.createElement('option');
        option.value = team.id;
        option.textContent = team.name;
        selectTeams.appendChild(option);
    });
    // -- Load teams
    // ++ Load employees on team select
    async function onTeamSelectChange() {
        const selectEmployees = document.getElementById('selectEmployees1');
        selectEmployees.innerHTML = '';
        const teamId = selectTeams.value;
        const response = await fetch(apiRoot + '/Teams/' + teamId + '/employees');
        const employees = await response.json();

        employees["employeesSteps"].forEach(employee => { // { id, name, totalSteps }
            const option = document.createElement('option');
            option.value = employee.id;
            option.textContent = employee.name;
            selectEmployees.appendChild(option);
        });
    }
    selectTeams.addEventListener('change', onTeamSelectChange);
    // -- Load employees on team select
    if (teams.length > 0) { // Fire the change event to load employees for the first team
        selectTeams.dispatchEvent(new Event('change'));
    }
    // ++ Button click handler
    const buttonAddCounter = document.getElementById('buttonAddCounter1');
    async function onAddCounter() {
        const data = {
            value: document.getElementById('inputCounterValue1').value,
            employeeId: document.getElementById('selectEmployees1').value
        };
        const response = await fetch(apiRoot + '/Counters/add', {
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
    // -- Button click handler
}
document.addEventListener('DOMContentLoaded', addCounterHandler);