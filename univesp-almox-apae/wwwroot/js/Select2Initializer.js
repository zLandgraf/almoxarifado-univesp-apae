function IniciaSelect2RemotoPadrao(
	selector,
	minInputLenght = 3,
	aditionalqueryParameters = {}
) {
	return $(selector).select2({
		ajax: {
			dataType: "json",
			delay: 250,
			data: function (params) {
				return {					
					search: params.term,
					pagina: params.page || 1,
					...aditionalqueryParameters
				};
			},
			processResults: function (data, params) {
				let optionsId = $(selector)
					.select2("data")
					.map((data) => parseInt(data.id));

				let results = data.results.filter(
					(result) => !optionsId.find((opt) => opt === parseInt(result.id))
				);

				params.page = params.page || 1;
				return {
					results: results,
					pagination: {
						more: params.page * 5 < data.total_count,
					},
				};
			},
			cache: true,
		},
		allowClear: true,
		language: "pt-BR",
		minimumInputLength: minInputLenght,		
	});
}

function IniciaSelect2RemotoPadraoComDropdownParent(
	selector,
	minInputLenght = 3,
	dropdownParent,
	dropdownParentForm,
	aditionalqueryParameters = {}
) {
	revalidaForm(dropdownParentForm);

	return $(selector).select2({
		dropdownParent: $(dropdownParent),
		ajax: {
			dataType: "json",
			delay: 250,
			data: function (params) {
				return {
					search: params.term,
					pagina: params.page || 1,
					...aditionalqueryParameters
				};
			},
			processResults: function (data, params) {
				let optionsId = $(selector)
					.select2("data")
					.map((data) => parseInt(data.id));

				let results = data.results.filter(
					(result) => !optionsId.find((opt) => opt === parseInt(result.id))
				);

				params.page = params.page || 1;
				return {
					results: results,
					pagination: {
						more: params.page * 5 < data.total_count,
					},
				};
			},
			cache: true,
		},
		allowClear: true,
		language: "pt-BR",
		minimumInputLength: minInputLenght,
	});
}