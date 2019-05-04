

///Método geral que chama todas as outras caixas de diálogo
///Recebe o json da controler ref. a business\viewmodel\MensagemModel
function mostrarMensagem(data) {

    if (data.MensagemTipo === "Sucesso") {
        mostrarMensagemSucesso(data);
    } else if (data.MensagemTipo === "Erro") {
        mostrarMensagemErro(data);
    } 
}

///Mostra a mensagem de sucesso
function mostrarMensagemSucesso(data) {
    if (data.Mensagem != null && data.Mensagem !== "") {
        $("#divSucessoDialogo p").html("<img src='../images/icone_msn_sucesso.png' />&nbsp;&nbsp;" + data.Mensagem);
        $("#divSucessoDialogo").modal("show");
    }
}

///Mostra a mensagem de erro 
function mostrarMensagemErro(data) {
    if (data.Mensagem != null && data.Mensagem !== "") {

        $("#divErrorDialogo p").html("<img src='../images/icone_msn_erro.png' />&nbsp;&nbsp;" + data.Mensagem);
        $("#divErrorDialogo").modal("show");
    }
}

//Exemplo de uso com Ajax

function Teste() {

    $.ajax({
        cache: false,
        type: 'POST',
        url: '@Href("~/Controller/Action")',
        data: dados,
        beforeSend: saveLoader,
        success: function (data) {
            debugger;
            if (data.tipo === "Erro") {
                var objMensagem = { "MensagemTipo": "Erro", "Mensagem": data.mensagem };
                mostrarMensagem(objMensagem);
            } else {
                var $tipoMensagem = 'Sucesso';
                var $mensagem = data.mensagem;

                if ($mensagem === undefined) {
                 
                }
                else {
                    var objMensagem = { 'MensagemTipo': $tipoMensagem, 'Mensagem': $mensagem };
                    mostrarMensagem(objMensagem);
                   
                    closeLoader();
                }

            }
        },
        complete: function () {
            closeLoader();
        },
        error: function (data) {
            var objMensagem = { "MensagemTipo": "Erro", "Mensagem": 'mensagem' };
            mostrarMensagem(objMensagem);
        }
    });
}

function openLoader() {
    $('body').append('<div class="ui-widget-overlay ui-front overlay-carregando"><div class="loader center">Carregando...</div></div>');
}

function saveLoader() {
    $('body').append('<div class="ui-widget-overlay ui-front overlay-carregando"><div class="loader center">Salvando...</div></div>');
}

function closeLoader() {
    $(".overlay-carregando").remove();
}

function deleteLoader() {
    $('body').append('<div class="ui-widget-overlay ui-front overlay-carregando"><div class="loader center">Excluindo...</div></div>');
}