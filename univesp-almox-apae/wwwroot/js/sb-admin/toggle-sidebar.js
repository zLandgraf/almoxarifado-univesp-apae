
window.addEventListener('DOMContentLoaded', event => {
	let midia = window.matchMedia("(max-width: 991px)");
	
	const sidebarToggle = document.body.querySelector('#sidebarToggle');

	if (sidebarToggle) {
		if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
			if (!midia.matches) {
				document.body.classList.toggle('sb-sidenav-toggled');
			}
		}

		sidebarToggle.addEventListener('click', event => {
			event.preventDefault();

			document.body.classList.toggle('sb-sidenav-toggled');
			
			localStorage.setItem('sb|sidebar-toggle',
				document.body.classList.contains('sb-sidenav-toggled')
			);
		});
	}
});