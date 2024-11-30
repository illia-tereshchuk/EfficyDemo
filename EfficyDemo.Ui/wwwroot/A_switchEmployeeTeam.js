async function switchEmployeeTeam() {
    const selectEmployees = document.getElementById('selectEmployeesA');
    const selectTeams = document.getElementById('selectTeamsA');
    const inputCurrentTeam = document.getElementById('inputCurrentTeamA');
    const buttonSwitchTeam = document.getElementById('buttonSwitchTeamA');

    async function onEmployeeSelectChange() {
        const employeeId = selectEmployees.value;
        const selectedEmployee = selectEmployees.options[selectEmployees.selectedIndex];
        const teamName = selectedEmployee.getAttribute('data');
        inputCurrentTeam.value = teamName; // Show team in label
        // Load teams
        const response = await fetch(`${apiRoot}/Teams/getAll`);
        const teams = await response.json();
        populateSelect(selectTeams, teams, 'id', 'name');
        // Remove current team from available selection
        const optionToRemove = Array.from(selectTeams.options).find(option => option.text === teamName);
        if (optionToRemove) {
            optionToRemove.remove();
        }
    }
    selectEmployees.addEventListener('change', onEmployeeSelectChange);

    // Load employees
    const response = await fetch(`${apiRoot}/Employees/getAll`);
    const employees = await response.json();
    populateSelect(selectEmployees, employees, 'id', 'name', 'teamName');

    // Button click handler
    async function onSwitchTeam() {
        const employeeId = selectEmployees.value;
        const newTeamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Employees/switchTeam?employeeId=${employeeId}&newTeamId=${newTeamId}`, {
            method: 'POST'
        });
        if (response.ok) {
            alert('Employee team updated successfully');
        } else {
            const error = await response.json();
            alert(`Failed to update employee team: ${error.message}`);
        }
    }
    buttonSwitchTeam.addEventListener('click', onSwitchTeam);
    
}
document.addEventListener('DOMContentLoaded', switchEmployeeTeam);