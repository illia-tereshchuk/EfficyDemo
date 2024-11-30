async function deleteTeamHandler() {
    const selectTeams = document.getElementById('selectTeams6');
    const buttonDeleteTeam = document.getElementById('buttonDeleteTeam6');

    // Load teams
    const response = await fetch(`${apiRoot}/Teams/getAll`);
    const teams = await response.json();
    populateSelect(selectTeams, teams, 'id', 'name');

    async function onDeleteTeam() {
        const response = await fetch(`${apiRoot}/Teams/delete/${selectTeams.value}`, {
            method: 'DELETE',
            headers: { 'accept': 'text/plain' }
        });
        if (response.ok) {
            alert('Deleted successfully');
            selectTeams.options[selectTeams.selectedIndex].remove();
        } else {
            const error = await response.json();
            alert(`Failed to delete: ${error.message}`);
        }
    }
    buttonDeleteTeam.addEventListener('click', onDeleteTeam);
}
document.addEventListener('DOMContentLoaded', deleteTeamHandler);