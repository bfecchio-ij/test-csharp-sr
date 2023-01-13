$("#frmRegister").validate({
    highlight: function (element) {
        $(element).parent().addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).parent().removeClass('has-error');
    },
    errorElement: 'span',
    errorClass: 'validation-error-message help-block form-helper bold',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});

$("#btnSaveCandidate").on("click", function (e) {

    if (!$("#frmRegister").valid())
        return;

    e.preventDefault();

    $(".loading").fadeIn("slow");

    var url = $("#Candidate_Id").val() == "0" ? "/Curriculum/Candidate/Register" : "/Curriculum/Candidate/Edit";

    $.post(url, $("#frmRegister").serialize(), function (retorno) {
        if (retorno.flSucesso) {
            toastr.success(retorno.mensagem);

            if ($("#Candidate_Id").val() == "0")
                $("#Candidate_Id").val(retorno.idCandidate);

            $("#dvCandidateExperiences").removeClass("hidden");
            $("#frmRegister").attr("action", "/Curriculum/Candidate/Edit");
        }
        else {
            toastr.error(retorno.mensagem);
        }
    })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastr.error(textStatus);
        })
        .always(function () {
            $(".loading").fadeOut("slow");
        });
});

/****************************************************************************************************************
 * Candidate Experiences
 ****************************************************************************************************************/
$("#btnAddExperience").on("click", function () {
    var idCandidate = $("#Candidate_Id").val();
    $("#conteudo").load("/Curriculum/Candidate/RegisterExperience/" + idCandidate, function () {
        $("#titulo").text("Register Candidate Experience");
        $('[data-toggle="tooltip"]').tooltip();
        $(".modal").modal();
        $("#frmRegisterCandidateExperience").validate({
            highlight: function (element) {
                $(element).parent().addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).parent().removeClass('has-error');
            },
            errorElement: 'span',
            errorClass: 'validation-error-message help-block form-helper bold',
            errorPlacement: function (error, element) {
                if (element.parent('.input-group').length) {
                    error.insertAfter(element.parent());
                } else {
                    error.insertAfter(element);
                }
            }
        });
        $("#Salary").maskMoney({
            prefix: 'R$ ',
            allowNegative: true,
            thousands: '.',
            decimal: ',',
            affixesStay: false
        });
        $("#BeginDate").on("blur", function () {
            $("#EndDate").attr("min", $(this).val());
        });
        $("#btnSaveExperience").on("click", function (e) {

            if (!$("#frmRegisterCandidateExperience").valid())
                return;

            e.preventDefault();

            $(".loading").fadeIn("slow");
            $.post("/Curriculum/Candidate/RegisterExperience", $("#frmRegisterCandidateExperience").serialize(), function (retorno) {
                $("#tbCandidateExperience tbody tr").remove();
                $("#tbCandidateExperience tbody").append(retorno);
                deleteExperience();
                editExperience();
            })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    toastr.error(textStatus);
                })
                .always(function () {
                    $(".modal").modal('toggle');
                    $(".loading").fadeOut("slow");
                });
        });
    });
});

editExperience();
function editExperience() {
    $(".editExperience").on("click", function () {
        var id = $(this).closest("tr").data("id");
        $("#conteudo").load("/Curriculum/Candidate/EditExperience/" + id, function () {
            $("#titulo").text("Edit Candidate Experience");
            $('[data-toggle="tooltip"]').tooltip();
            $(".modal").modal();
            $("#frmRegisterCandidateExperience").validate({
                highlight: function (element) {
                    $(element).parent().addClass('has-error');
                },
                unhighlight: function (element) {
                    $(element).parent().removeClass('has-error');
                },
                errorElement: 'span',
                errorClass: 'validation-error-message help-block form-helper bold',
                errorPlacement: function (error, element) {
                    if (element.parent('.input-group').length) {
                        error.insertAfter(element.parent());
                    } else {
                        error.insertAfter(element);
                    }
                }
            });
            $("#Salary").maskMoney({
                prefix: 'R$ ',
                allowNegative: true,
                thousands: '.',
                decimal: ',',
                affixesStay: false
            });
            $("#BeginDate").on("blur", function () {
                $("#EndDate").attr("min", $(this).val());
            });
            $("#btnSaveExperience").on("click", function (e) {

                if (!$("#frmRegisterCandidateExperience").valid())
                    return;

                e.preventDefault();

                $(".loading").fadeIn("slow");
                $.post("/Curriculum/Candidate/EditExperience/", $("#frmRegisterCandidateExperience").serialize(), function (retorno) {
                    $("#tbCandidateExperience tbody tr").remove();
                    $("#tbCandidateExperience tbody").append(retorno);
                    deleteExperience();
                    editExperience();
                })
                    .fail(function (jqXHR, textStatus, errorThrown) {
                        toastr.error(textStatus);
                    })
                    .always(function () {
                        $(".modal").modal('toggle');
                        $(".loading").fadeOut("slow");
                    });
            });
        });
    });
}

deleteExperience();
function deleteExperience() {
    $(".deleteExperience").on("click", function () {
        var row = $(this).closest("tr");
        var id = $(this).closest("tr").data("id");
        bootbox.confirm({
            message: 'Do you want to delete this record ?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $(".loading").fadeIn("slow");
                    $.post("/Curriculum/Candidate/DeleteExperience/" + id, function (retorno) {
                        if (retorno.flSucesso) {
                            toastr.success(retorno.mensagem);
                            row.remove();
                        }
                        else {
                            toastr.error(retorno.mensagem);
                        }
                    })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            toastr.error(textStatus);
                        })
                        .always(function () {
                            $(".loading").fadeOut("slow");
                        });
                }
            }
        });
    });
}