var editor = ace.edit("aiml-edit");
editor.setTheme("ace/theme/iplastic");
editor.session.setMode("ace/mode/xml");
editor.setAutoScrollEditorIntoView(true);
editor.setOptions({
    fontFamily: "tahoma",
    fontSize: "10pt",
    readOnly: true,
    useWorker: false
});

var workspace = Blockly.inject('blocklyDiv',
    {
        media: '/Content/media/',
        toolbox: window.blockly_toolbox
    });

window.blockly_workspace = workspace;

var xmlString = $("#blocklyWorkspace").val() || window.blockly_workspace;
var xml = Blockly.Xml.textToDom(xmlString);
Blockly.Xml.domToWorkspace(xml, workspace);
workspace.addChangeListener(function () {
    var aiml = Blockly.JavaScript.workspaceToCode(workspace);
    var topicId = $("#TopicId").val();
    if (topicId)
        aiml = '<topic name="' + topicId + '">\n' + aiml + "\n</topic>";



    $(".codeContainer").val(aiml);
    editor.setValue(aiml, -1);

    var xml = Blockly.Xml.workspaceToDom(workspace);
    var xml_text = Blockly.Xml.domToText(xml);
    $("#blocklyWorkspace").val(xml_text);
});

var setDisabledForBlockAndChilds = function (block) {
    block.setDisabled(!block.parentBlock_ || block.parentBlock_.disabled);

    for (var item of block.childBlocks_) {
        arguments.callee(item);
    }

};

var qBlocks = ["category"];
workspace.addChangeListener(function (event) {
    if (event.type == Blockly.Events.MOVE) {
        var block = workspace.getBlockById(event.blockId);

        if (block && qBlocks.filter(function (el) {
            return el == block.type;
        }).length == 0) {
            setDisabledForBlockAndChilds(block);
        }

    }


});