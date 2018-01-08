$(document).ready(function () {
    $("#jqGridTable").jqGrid({
        url: '/api/SkillsApi/All',
        datatype: "json",
        autowidth: true,
        colNames: ['Название', 'Автор', 'Дата создания', 'Последний редактор', 'Дата изменения', 'Описание навыка'],
        colModel: [
            {
                name: 'Name', index: 'Name', sortable: true, editable: true, edittype: 'text',
                searchoptions: { sopt: [] }
            },
            { name: 'Creator', index: 'Creator' },
            {
                name: 'CreatedOn', index: 'CreatedOn', sortable: true,
                searchoptions: { sopt: [] }
            },
            {
                name: 'LastEditor', index: 'LastEditor',
                searchoptions: { sopt: [] }
            },
            {
                name: 'ChangedOn', index: 'ChangedOn', sortable: true,
                searchoptions: { sopt: [] }
            },
            {
                name: 'Description', index: 'Description', editable: true, edittype: 'textarea',
                hidden: true, editrules: { edithidden: true },
                searchoptions: { sopt: [] }
            }
        ],
        rowNum: 20,
        viewrecords: true,
        pager: '#jpager',
        rowList: [20, 50, 100],
        sortname: 'CreatedOn',
        sortorder: "desc",
        caption: "Список навыков",
        defaultSearch: "cn",
    })
    .jqGrid('navGrid', '#jpager', {

        add: true,
        del: true,
        edit: true,
        search: true,
        searchtext: "Поиск",
        refresh: true,
        refreshtext: "Обновить",
        viewtitle: "Выбранная запись",
        addtext: "Добавить",
        edittext: "Изменить",
        deltext: "Удалить"
    },
    update("edit"), // обновление
    update("add"), // добавление
    update("del"), // удаление
    { // поиск
        afterRedraw: function () {
            $(this).find(".operators").hide();
        }
    }
    );

function update(act) {
    return {
        closeAfterAdd: true, // закрыть после добавления
        height: 350,
        width: 500,
        closeAfterEdit: true, // закрыть после редактирования
        reloadAfterSubmit: true, // обновление
        drag: true,
        onclickSubmit: function (params) {
            var list = $("#jqg");
            var selectedRow = list.getGridParam("selrow");
            rowData = list.getRowData(selectedRow);
            params.url = '/api/SkillsApi';
            if (act === "add" || act === "edit")
                params.mtype = 'POST';
            else if (act === "del")
                params.mtype = 'DELETE';
        },
        afterSubmit: function (response, postdata) {
            // обновление грида
            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')
            return [true, "", 0]
        }
    };
};
});