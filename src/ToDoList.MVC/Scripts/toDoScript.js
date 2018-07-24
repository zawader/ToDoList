$(document).ready(gridConfiguration);
function gridConfiguration() {

    var traducao = {
        all: "Todos",
        infos: "Exibindo {{ctx.start}} até {{ctx.end}} de {{ctx.total}} registros",
        loading: "Carregando...",
        noResults: "Não há dados para exibir!",
        refresh: "Atualizar",
        search: "Pesquisar"
    }

    var grid = $("#todo-data").bootgrid({
        ajax: true,
        url: "http://localhost:26716/tarefas/GetAll",
        labels: traducao,
        searchSettings: {
            delay: 200,
            characters: 2
        },
        formatters: {
            "dateformatter": function (column, row) {
                //var strDate = row.CreateDate.substring(6, 9) + "/" + row.CreateDate.substring(4, 6) + "/" + row.CreateDate.substring(0, 4);
                return moment.utc(row[column.CreateDate]).format('DD/MM/YYYY');
            },
            "actions": function (column, row) {
                return "<a href='#' data-acao='Detalhes' data-row-id='" + row.ToDoId + "' class='btn btn-info' title='Exibir detalhes da Tarefa'><span class='glyphicon glyphicon-edit'></span></a> " +
                    "<a href='#' data-acao='Editar' data-row-id='" + row.ToDoId + "' class='btn btn-warning' title='Editar Tarefa'><span class='glyphicon glyphicon-list'></span></a> " +
                    "<a href='#' data-acao='Deletar' data-row-id='" + row.ToDoId + "' class='btn btn-danger' title='Deletar Tarefa'><span class='glyphicon glyphicon-trash'></span></a> "
            },
            "completed": function (column, row) {

                if (row.IsCompleted) {
                    return "<span class='glyphicon glyphicon-ok alert-success'>";
                } else {
                    return "<span class='glyphicon glyphicon-remove alert-danger'>";
                }
            }
        }
    });

    grid.on("loaded.rs.jquery.bootgrid", function () {
        grid.find("a.btn").each(function (index, elemento) {
            var botaoDeAcao = $(elemento);
            var acao = botaoDeAcao.data("acao");
            var ToDoId = botaoDeAcao.data("row-id");

            botaoDeAcao.on("click", function () {
                AbrirModal(acao, ToDoId);
            });
        });
    });

    $("a.btn").click(function () {
        var acao = $(this).data("action");
        AbrirModal(acao);
    });
}

function AbrirModal(acao, parametro) {

    var url = "/{ctrl}/{acao}/{parametro}";
    url = url.replace("{ctrl}", controller);
    url = url.replace("{acao}", acao);
    if (parametro != null)
        url = url.replace("{parametro}", parametro);
    else
        url = url.replace("{parametro}", "");

    $("#modalTarefas").show("show");
    $("#conteudoModal").load(url, function () {
        $("#modalTarefas").modal("show");
    });



}