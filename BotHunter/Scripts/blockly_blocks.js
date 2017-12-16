Blockly.Blocks['category'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Диалог");
        this.appendValueInput("NAME")
            .setCheck("Topic")
            .setAlign(Blockly.ALIGN_RIGHT)
            .appendField("тема");
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
            .appendField(new Blockly.FieldTextInput("название темы"), "NAME");
        this.setOutput(true, "Topic");
        this.setColour(0);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};


/***************************     Генератор        ******************************/
Blockly.Aiml = new Blockly.Generator('Aiml');

Blockly.Aiml['category'] = function (block) {
    var value_name = Blockly.Aiml.valueToCode(block, 'NAME');
    var statements_pattern = Blockly.Aiml.statementToCode(block, 'Pattern');
    var statements_template = Blockly.Aiml.statementToCode(block, 'Template');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['user_text'] = function (block) {
    var text_text = block.getFieldValue('text');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['bot_text'] = function (block) {
    var text_text = block.getFieldValue('text');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['star'] = function (block) {
    var dropdown_indecs = block.getFieldValue('indecs');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['srai'] = function (block) {
    var statements_template = Blockly.Aiml.statementToCode(block, 'Template');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['random'] = function (block) {
    var statements_variants = Blockly.Aiml.statementToCode(block, 'variants');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['random_el'] = function (block) {
    var text_text = block.getFieldValue('text');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['set'] = function (block) {
    var text_var = block.getFieldValue('VAR');
    var text_val = block.getFieldValue('VAL');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['get'] = function (block) {
    var text_name = block.getFieldValue('NAME');
    var dropdown_vartype = block.getFieldValue('vartype');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['think'] = function (block) {
    var statements_blocks = Blockly.Aiml.statementToCode(block, 'blocks');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['condition'] = function (block) {
    var text_var = block.getFieldValue('VAR');
    var text_val = block.getFieldValue('VAL');
    var statements_conditions = Blockly.Aiml.statementToCode(block, 'conditions');
    // TODO: Assemble Aiml into code variable.
    var code = '...;\n';
    return code;
};

Blockly.Aiml['topic'] = function (block) {
    var text_name = block.getFieldValue('NAME');
    // TODO: Assemble Aiml into code variable.
    var code = '...';
    // TODO: Change ORDER_NONE to the correct strength.
    return [code];
};

