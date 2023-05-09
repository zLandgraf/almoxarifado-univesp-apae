function SucessoModal(response, modalSelector) {
	Sucesso(response);

	if (!response.erro) {
		var modalElement = document.querySelector(modalSelector);
		var modal = new bootstrap.Modal(modalElement);
		modal.show();
	}
}