function toCamelCase(o) {
    var newO, origKey, newKey, value
    if (o instanceof Array) {
        return o.map(function (value) {
            if (typeof value === "object") {
                value = toCamelCase(value)
            }
            return value
        })
    } else {
        newO = {}
        for (origKey in o) {
            if (o.hasOwnProperty(origKey)) {
                newKey = (origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey).toString()
                value = o[origKey]
                if (value instanceof Array || (value !== null && value.constructor === Object)) {
                    value = toCamelCase(value)
                }
                newO[newKey] = value
            }
        }
    }
    return newO
}

function pedirConfirmacao(evt, el) {
    var msg = $(el).attr("data-ajax-confirmation");
    if (msg !== undefined && msg != "") {
        evt.preventDefault;
        evt.stopPropagation;
        Swal.fire({
            title: "Tem certeza?",
            text: msg,
            icon: "question",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sim",
            cancelButtonText: "Não",
        }).then((result) => {
            if (result.isConfirmed) {
                var confirmation = $(el).attr("data-ajax-confirmation");
                $(el).removeAttr("data-ajax-confirmation");
                $(el).unbind(evt);
                if (evt.type == "click") {
                    $(el).click();
                } else {
                    $(el).submit();
                }
                $(el).attr("data-ajax-confirmation", confirmation);
                confirmacao();
            }
        });
        return false;
    }
    return true;
}

confirmacao();

function confirmacao() {
    $("body").on("click", "a[data-ajax-confirmation]", function (evt) {
        pedirConfirmacao(evt, this);
        return false;
    });
    $("body").on("submit", "[data-ajax-confirmation]", function (evt) {
        pedirConfirmacao(evt, this);
        return false;
    });
}

function Carregando(xhr) {
    securityToken = $("[name=__RequestVerificationToken]").val();
    xhr.setRequestHeader("RequestVerificationToken", securityToken);
    setLoading(true);
    DesabilitaInputs();
}

function Completo() {
    HabilitaInputs();
    setLoading(false);
}

function Sucesso(data) {
    revalidaForm();
    setLoading(false);
    if (!data.erro) {
        if (data.msg) {
            Swal.fire({
                title: data.warning ? "Alerta" : "Sucesso",
                text: data.msg,
                icon: data.warning ? "warning" : "success",
                timer: data.await ? data.await : (data.warning ? 2500 : 1500),
                showConfirmButton: false,
                showCloseButton: true,
            }).then(function () {
                if (data.url) {
                    Redirecionando(data.url, data.novaguia);
                }
                if (data.reload) {
                    document.location.reload(true);
                }
            });
        }
        if (data.limparCampos) {
            LimparCampos();
        }
    } else {
        Falha(data);
    }
}

function SucessoModal(data, modalId) {
    Sucesso(data);
    if (!data.erro) {
        var modal = new bootstrap.Modal(document.getElementById(modalId));
        modal.show();
    }
}

function Falha(data) {
    setLoading(false);
    let { msg, status, url, novaguia } = data;
    if (!msg) {
        switch (status) {
            case 403: {
                msg =
                    "Permissão negada! Você não tem permissão para acessar esta função.";
                break;
            }
            case 404: {
                msg = "Erro 404! Página não encontrada!";
                break;
            }
            case 408: {
                msg = "Time out! Verifique sua conexão e tente novamente.";
                break;
            }
            case 413: {
                msg =
                    "Requisição muito grande! Verifique a quantidade/tamanho dos arquivos e tente novamente.";
                break;
            }
            case 415: {
                msg =
                    "Requisição muito grande! Verifique a quantidade/tamanho dos arquivos e tente novamente.";
                break;
            }
            case 503: {
                msg =
                    "Servidor indisponível! O servidor pode estar em manutenção ou sobrecarregado.";
                break;
            }
            case 504: {
                msg = "Time out! O servidor não pode processar sua requisição a tempo.";
                break;
            }
            default: {
                msg =
                    "Ocorreu um erro inesperado. Sistema indisponível no momento. Por favor, tente novamente mais tarde...";
            }
        }
    }
    Swal.fire({
        title: "Falha",
        text: msg,
        icon: "error",
        showCloseButton: true,
        showConfirmButton: false,
    }).then(function () {
        if (url) {
            Redirecionando(url, novaguia);
        }
    });
}

function Redirecionando(url, novaguia) {
    if (novaguia) {
        window.open(url, "_blank");
    } else {
        $("input").attr("disabled", "disabled");
        $("select").attr("disabled", "disabled");
        $("textarea").attr("disabled", "disabled");
        $(".btn").attr("disabled", "disabled");
        window.location = url;
    }
}

function DesabilitaInputs() {
    $("input").attr("disabled", "disabled");
    $("select").attr("disabled", "disabled");
    $("textarea").attr("disabled", "disabled");
    $(".btn").attr("disabled", "disabled");
}

function HabilitaInputs() {
    $("input").removeAttr("disabled");
    $("select").removeAttr("disabled");
    $("textarea").removeAttr("disabled");
    $(".btn").removeAttr("disabled");
    $(".disabled").attr("disabled", "disabled");
}

function LimparCampos() {
    $("input:text").val("");
    $("input:password").val("");
    $("select").val("");
    $("textarea").val("");
}

function revalidaForm() {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
}

function revalidaForm(formSelector) {
    $(formSelector).removeData("validator");
	$(formSelector).removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(formSelector);
}

function colocaNomeArquivoLabel() {
    $(".custom-file-input").on("change", function () {
        var fileLabel = $(this).next(".custom-file-label");
        var files = $(this)[0].files;
        if (files.length > 1) {
            fileLabel.html(files.length + " arquivos selecionados");
        } else if (files.length == 1) {
            fileLabel.html(files[0].name);
        } else {
            fileLabel.html("Selecione os arquivos");
        }
    });
}

function ReorganizaNomesInputsSeletor(selector, nome, propriedade) {
    $(selector).each(function (i) {
        if (propriedade != "") {
            $(this).attr("name", `${nome}[${i}].${propriedade}`);
            $(this).attr("id", `${nome}[${i}].${propriedade}`);
            if ($(this).attr("for") !== undefined) {
                $(this).attr("for", `${nome}[${i}].${propriedade}`);
            }
        } else {
            $(this).attr("name", `${nome}[${i}]`);
            $(this).attr("id", `${nome}[${i}]`);
            if ($(this).attr("for") !== undefined) {
                $(this).attr("for", `${nome}[${i}]`);
            }
        }
    });
}

function ReorganizaNomesValidadorInputsSeletor(selector, nome, propriedade) {
    if (propriedade != "") {
        $(selector).each(function (i) {
            $(this).attr("data-valmsg-for", `${nome}[${i}].${propriedade}`);
        });
    } else {
        $(selector).each(function (i) {
            $(this).attr("data-valmsg-for", `${nome}[${i}]`);
        });
    }
}

function setLoading(loading) {
    return loading
        ? $("body").append(loadingSpinnerTemplate())
        : $(".loading-container").fadeOut(500, function () {
            $(this).remove();
        });
}

function loadingSpinnerTemplate() {
    return `
        <div class="loading-container">
            <div class="loading-spinner spinner-border" role="status">
                <span class="sr-only">Carregando...</span>
            </div>
         <div class="loading-container">
    `;
}

function convertToFloat(valueString) {
    if (valueString.includes(",")) {
        return parseFloat(valueString.replace(".", "").replace(",", "."));
    }
    else {
        return parseFloat(valueString);
    }
}
