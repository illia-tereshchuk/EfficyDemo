async function getStepsByTeamHandler() {
    const selectTeams = document.getElementById('selectTeams3');
    const inputTeamSteps = document.getElementById('inputTeamSteps3');
    // Load steps on team select
    async function onTeamSelectChange() {
        const teamId = selectTeams.value;
        const response = await fetch(`${apiRoot}/Teams/steps/${teamId}`);
        const steps = await response.text();
        inputTeamSteps.value = steps;
    }
    selectTeams.addEventListener('change', onTeamSelectChange);
    // Load teams
    const response = await fetch(`${apiRoot}/Teams/getAll`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');
}

document.addEventListener('DOMContentLoaded', getStepsByTeamHandler);
