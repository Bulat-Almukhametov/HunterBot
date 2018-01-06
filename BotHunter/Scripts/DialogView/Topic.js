function deselectTopic() {
    var tree = $("#topics").jstree(true);
    tree.deselect_all();
    $("#TopicId").val("");
    window.blockly_workspace.fireChangeListener(window.blockly_workspace);
};

$(document).tooltip();
function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

$(function () {
    $treeview = $("#topics");

    $treeview.jstree({
        "core": {
            "animation": 0,
            "check_callback": true,
            "data": {
                "type": "POST",
                "dataType": "json",
                "contentType": "application/json;",
                "url": "/Topic/All"

            },
        },
        "types": {
            "default": {
                "icon": "/Content/topic_ico.png"
            },
            "Office": {
                "icon": "/Content/office.png"
            },
            "HR": {
                "icon": "/Content/hr.png"
            },
            "Technical": {
                "icon": "/Content/experience.png"
            },
        },
        "contextmenu": {
            "items": function ($node) {
                var tree = $treeview.jstree(true);
                var result = {
                    "Create": {
                        "separator_before": false,
                        "separator_after": false,
                        "label": "Добавить",
                        "action": function (obj) {
                            var node = tree.create_node($node, { id: uuidv4(), text: "Новая тема", });

                            tree.deselect_all();
                            tree.select_node(node);
                            node = tree.get_node(node);

                            var parent = tree.get_node(node.parent);

                            $("#topicForm").populate({
                                Id: node.id,
                                ParentName: parent.text,
                                ParentId: parent.id,
                                Name: node.text,
                            });
                            window.topicModalbox.dialog("open");
                        }
                    },
                    "Rename": {
                        "separator_before": false,
                        "separator_after": false,
                        "label": "Изменить",
                        "action": function (obj) {
                            $("#topicForm").populate($node.data);
                            window.topicModalbox.dialog("open");
                        }
                    }
                };

                if (!$node.children.length)
                    result["Remove"] = {
                        "separator_before": false,
                        "separator_after": false,
                        "label": "Удалить",
                        "action": function (obj) {
                            $.ajax({
                                type: "POST",
                                url: "/Topic/Delete",
                                data: { id: $node.id },
                                success: function (data) {
                                    if (data.success) {
                                        tree.delete_node($node);
                                        deselectTopic();
                                    }
                                    else {
                                        console.error("Ошибка при сохранении темы диалога: ", data.error);
                                    }
                                },
                                error: function (data) {
                                    console.error("Ошибка при обращению к серверу: ", data);
                                }
                            });
                        }
                    };

                return result;

            }
        },
        "plugins": [
            "contextmenu",
            "types",
            "wholerow"
        ]
    })
        .on('loaded.jstree', function () {
            $treeview.jstree('open_all');
            var tree = $treeview.jstree(true);

            var topicId = $("#TopicId").val();
            if (topicId)
                tree.select_node(topicId);

        })
        .on("select_node.jstree", function (event, params) {
            $("#TopicId").val(params.node.id);
            blockly_workspace.fireChangeListener(blockly_workspace);
        });
});

$("#addRootTopic").click(function () {
    var tree = $("#topics").jstree(true);

    var node = tree.create_node("#", { id: uuidv4(), text: "Новая тема", });

    tree.deselect_all();
    tree.select_node(node);
    node = tree.get_node(node);

    $("#topicForm").populate({
        Id: node.id,
        Name: node.text,
    });
    window.topicModalbox.dialog("open");
});
$("#deselectTopic").click(function () {
    deselectTopic();
});