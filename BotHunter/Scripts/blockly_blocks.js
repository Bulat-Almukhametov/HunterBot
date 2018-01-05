Blockly.Blocks['category'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Диалог");
        this.appendStatementInput("Pattern")
            .setCheck("Pattern")
            .appendField("Пользователь");
        this.appendStatementInput("Template")
            .setCheck(["Template", "srai"])
            .appendField("Ответ");
        this.setColour(60);
        this.setTooltip("Создайте диалог, задавая ввод пользователя и выводимый ответ бота.");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['user_text'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("текст")
            .appendField(new Blockly.FieldTextInput("сообщение"), "text");
        this.setPreviousStatement(true, "Pattern");
        this.setNextStatement(true, "Pattern");
        this.setColour(150);
        this.setTooltip("Текст пользователя");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['bot_text'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("текст")
            .appendField(new Blockly.FieldTextInput("сообщение"), "text");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip("Введите отправляемое сообщение");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['star'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("вхождение  * ")
            .appendField(new Blockly.FieldDropdown([["1", "1"], ["2", "2"], ["3", "3"], ["4", "4"], ["5", "5"], ["6", "6"], ["7", "7"], ["8", "8"]]), "indecs")
            .appendField("-е");
        this.setPreviousStatement(true, "Pattern");
        this.setNextStatement(true, "Pattern");
        this.setColour(240);
        this.setTooltip("Выводит слово или последовательность символов пользователя, которые были на месте со звездочкой.");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['srai'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Переадресовать");
        this.appendStatementInput("Template")
            .setCheck("Template")
            .appendField("на");
        this.setPreviousStatement(true, "srai");
        this.setColour(240);
        this.setTooltip("Переадресует на другой диалог. Не используйте с другими блоками.");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['random'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Случайно выбрать");
        this.appendStatementInput("variants")
            .setCheck("variant")
            .appendField("из");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip("Выбирает случайным образом один из вариантов");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['random_el'] = {
    init: function () {
        this.appendDummyInput()
            .appendField(new Blockly.FieldImage("https://upload.wikimedia.org/wikipedia/commons/c/c4/2-Dice-Icon.svg", 18, 20, "*"))
            .appendField(new Blockly.FieldTextInput("default"), "text");
        this.setPreviousStatement(true, "variant");
        this.setNextStatement(true, "variant");
        this.setColour(240);
        this.setTooltip("Вариант  ответа");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['set'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("установить")
            .appendField(new Blockly.FieldTextInput("название переменной"), "VAR")
            .appendField("=")
            .appendField(new Blockly.FieldTextInput("значение"), "VAL");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['get'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Получить");
        this.appendDummyInput()
            .appendField(new Blockly.FieldTextInput("название"), "NAME")
            .appendField("из")
            .appendField(new Blockly.FieldDropdown([["переменной", "var"], ["свойства", "bot"]]), "vartype");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip(" Получает значение из переменной (изменяемое) или из свойства (заданное заранее).");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['think'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Не показывать");
        this.appendStatementInput("blocks")
            .setCheck("Template");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip("Предотвращает от показа текст, который может возникнуть при использовании блоков логики.");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['condition'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Если ")
            .appendField(new Blockly.FieldTextInput("название переменной"), "VAR")
            .appendField("=")
            .appendField(new Blockly.FieldTextInput("значение"), "VAL");
        this.appendStatementInput("conditions")
            .setCheck("Template")
            .appendField("то");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(240);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.Blocks['topic'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Перейти к теме");
        this.appendDummyInput()
            .appendField(new Blockly.FieldTextInput("название темы"), "NAME");
        this.setPreviousStatement(true, "Template");
        this.setNextStatement(true, "Template");
        this.setColour(0);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};


/***************************     Генератор        ******************************/

Blockly.JavaScript['category'] = function (block) {
    var statements_pattern = Blockly.JavaScript.statementToCode(block, 'Pattern');
    var statements_template = Blockly.JavaScript.statementToCode(block, 'Template');
    
    var code = `
<category>
    <pattern> ` + statements_pattern + ` </pattern>
    <template>
        ` + statements_template + `
    </template>
</category >
`;
    if (statements_pattern && statements_template)
        return code;
    else return "";
};

Blockly.JavaScript['user_text'] = function (block) {
    var text_text = block.getFieldValue('text');
    
    var code = text_text;
    return code;
};

Blockly.JavaScript['bot_text'] = function (block) {
    var text_text = block.getFieldValue('text');

    var code = text_text;
    return code;
};

Blockly.JavaScript['star'] = function (block) {
    var dropdown_indecs = block.getFieldValue('indecs');

    var code = '<star index = "' + dropdown_indecs + '"/>';
    return code;
};

Blockly.JavaScript['srai'] = function (block) {
    var statements_template = Blockly.JavaScript.statementToCode(block, 'Template');
    var code = '<srai>\n' + statements_template + '\n</srai>\n';
    return code;
};

Blockly.JavaScript['random'] = function (block) {
    var statements_variants = Blockly.JavaScript.statementToCode(block, 'variants');
    
    var code = '<random>\n' + statements_variants + '</random>\n';
    return code;
};

Blockly.JavaScript['random_el'] = function (block) {
    var text_text = block.getFieldValue('text');

    var code = '<li>' + text_text + '</li>\n';
    return code;
};

Blockly.JavaScript['set'] = function (block) {
    var text_var = block.getFieldValue('VAR');
    var text_val = block.getFieldValue('VAL');
   
    var code = '<set name = "' + text_var +'"> ' + text_val +' </set>\n';
    return code;
};

Blockly.JavaScript['get'] = function (block) {
    var text_name = block.getFieldValue('NAME');
    var dropdown_vartype = block.getFieldValue('vartype');
    var code = "";

    if (dropdown_vartype == "var")
        code = '<get name = "' + text_name + '"></get>\n';
    else if (dropdown_vartype == "bot")
        code = '<bot name = "' + text_name + '"/>\n';

    return code;
};

Blockly.JavaScript['think'] = function (block) {
    var statements_blocks = Blockly.JavaScript.statementToCode(block, 'blocks');
    
    var code = '<think>\n' + statements_blocks + '\n</think>\n';
    return code;
};

Blockly.JavaScript['condition'] = function (block) {
    var text_var = block.getFieldValue('VAR');
    var text_val = block.getFieldValue('VAL');
    var statements_conditions = Blockly.JavaScript.statementToCode(block, 'conditions');
    
    var code = '<condition name="' + text_var + '" value="' + text_val + '">\n' + statements_conditions + '\n</condition >\n';
    return code;
};

Blockly.JavaScript['topic'] = function (block) {
    var text_name = block.getFieldValue('NAME');
    
    var code = '<think> <set name="topic">' + text_name + '</set></think>\n';
    return code;
};

