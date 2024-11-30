async function fetchTeamsWithSteps() {
    const response = await fetch(apiRoot + '/Teams/all');
    const teams = await response.json();
    const tableBody = document.getElementById('teamsTable').getElementsByTagName('tbody')[0];
    teams.forEach(team => { // { id, name, totalSteps }
        const row = tableBody.insertRow();
        const nameCell = row.insertCell(0);
        const totalStepsCell = row.insertCell(1);
        nameCell.textContent = team.name;
        totalStepsCell.textContent = team.totalSteps;
    });
}
document.addEventListener('DOMContentLoaded', fetchTeamsWithSteps);