async function addTeamHandler() {
    const inputTeamName = document.getElementById('inputTeamName6');
    const buttonAddTeam = document.getElementById('buttonAddTeam6');

    async function onAddTeam() {
        const teamName = inputTeamName.value;
        inputTeamName.value = '';
        const response = await fetch(`${apiRoot}/Teams/add?name=${encodeURIComponent(teamName)}`, {
            method: 'POST',
            headers: { 'accept': 'text/plain' }
        });
        if (response.ok) {
            alert('New team added successfully');
        } else {
            const error = await response.json();
            alert(`Failed to add new team: ${error.message}`);
        }
    }
    buttonAddTeam.addEventListener('click', onAddTeam);
}
document.addEventListener('DOMContentLoaded', addTeamHandler);