async function switchEmployeeTeam() {
    const selectEmployees = document.getElementById('selectEmployeesBonus');
    const selectTeams = document.getElementById('selectTeamsBonus');
    const inputCurrentTeam = document.getElementById('inputCurrentTeamBonus');

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

    
}
document.addEventListener('DOMContentLoaded', switchEmployeeTeam);