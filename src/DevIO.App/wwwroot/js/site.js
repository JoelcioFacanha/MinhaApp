function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click", function (e) {
                $('#myModalContent').load(this.href, function () {
                    $('#myModal').modal({ keyboard: true }, 'show');
                    bindForm(this);
                });
                return false;
            });
        });


        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#enderecoTarget').load(result.url); // carrega o HTML para a div marcada com o id="EnderecoTarget"
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });

                return false;
            });
        }

    });
}

function BuscaCep() {

    $(document).ready(function () {

        // Limpa os valores
        $("#Endereco_Logradouro").val("");
        $("#Endereco_Bairro").val("");
        $("#Endereco_Cidade").val("");
        $("#Endereco_Estado").val("");

        $("#Endereco_Cep").blur(function () {

            var cep = $(this).val().replace(/\D/g, '...');

            if (cep != null) {

                var validaCep = /^[0-9]{8}$/;

                if (validaCep.test(cep)) {

                    $("#Endereco_Logradouro").val("...");
                    $("#Endereco_Bairro").val("...");
                    $("#Endereco_Cidade").val("...");
                    $("#Endereco_Estado").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                        if (!("erro" in dados)) {
                            // Atualiza os campos com os valores da consulta.
                            $("#Endereco_Logradouro").val(dados.logradouro);
                            $("#Endereco_Bairro").val(dados.bairro);
                            $("#Endereco_Cidade").val(dados.localidade);
                            $("#Endereco_Estado").val(dados.uf);
                        } else {
                            limpa_formulario_cep();
                            alert("Cep não encontrado!");
                        }
                    });
                } else {
                    //cep é inválido.
                    limpa_formulario_cep();
                    alert("Formato de CEP inválido!");
                }
            } else {
                //cep sem valor, limpa formulário.
                limpa_formulario_cep();
            }

        });
    });
}
