$("#tbCandidates").dataTable({
    stateSave: true,
    pageLength: 10,
    "stateDuration": 60 * 60 * 24
});

deleteCandidate();
function deleteCandidate() {
    $(".delete").on("click", function () {
        console.log("aqui");
        var row = $(this).closest("tr");
        var id = $(this).closest("tr").data("id");
        bootbox.confirm({
            message: 'Do you want to delete this candidate ?',
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
                    $.post("/Curriculum/Candidate/Delete/" + id, function (retorno) {
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