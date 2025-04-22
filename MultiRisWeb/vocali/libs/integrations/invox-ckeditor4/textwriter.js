
var INVOX_CKEditorv4_TextWriter = (function () {

    var textWriter = new INVOX.TextWriterBase();

    textWriter.WORD_DELIM = /[^A-zÀ-ÿ0-9]/g;
    textWriter.SENTENCE_DELIM = /\.\n|\.|\n\n|\n/g;
    textWriter.PARAGRAPH_DELIM = /\n\n/g;

    // Public methods

    textWriter.setEditor = function(editor)  {
        if(!(editor instanceof CKEDITOR.editor)){
            throw new Error("SetEditor requires a instance of CKEDITOR.editor");
        }
        this.editor = editor;
    }

    textWriter.getEditor = function()  {
        return this.editor;
    }

    textWriter.getText = function () {
        return getAllText(this.editor);
    }

    textWriter.getRichText = function () {
        return this.editor.getData();
    }

    textWriter.getSelection = function () {
        return getSelectionRange(this.editor);
    }
    textWriter.getTextContext = function(){
        var context = INVOX.TextWriterBase.prototype.getTextContext.call(this);
        context[0] = CleanText(context[0]);
        context[1] = CleanText(context[1]);
        return context;

        function CleanText(text) {
            var cleanText = text;
            var FILLING_CHAR_SEQUENCE = CKEDITOR.dom.selection.FILLING_CHAR_SEQUENCE;
            if (FILLING_CHAR_SEQUENCE && text) {
                cleanText = text.replace(new RegExp(FILLING_CHAR_SEQUENCE, 'g'), "");
            }
            return cleanText;
        }
    }
    textWriter.setSelection = function (range) {
        setSelectionRange(this.editor, range);
    }
    textWriter.redo = function () {
        this.editor.execCommand('redo');
    }
    textWriter.undo = function () {
        this.editor.execCommand('undo');
    }
    textWriter.updateRedoUndoStack = function () {
        this.editor.fire('saveSnapshot');
    }
    textWriter.write = function (text) {
        var fFocus = this.editor.focus;
        this.editor.focus = function () { };
        this.editor.insertText(text);
        this.editor.focus = fFocus;
    }
    textWriter.writeNewLine = function () {
        this.editor.execCommand('enter');
    }
    textWriter.writeNewParagraph = function () {
        this.writeNewLine();
        this.writeNewLine();
    }

    // Private methods

    function getAllText (editor) {
        var allText = "";
        if (editor) {
            var lockSelection = editor.lockSelection();
            var walker = walkerFromBodyWithoutFakeElements(editor);
            while (node = walker.previous()) {
                allText = getCustomText(node) + allText;
            }
            if (lockSelection) {
                editor.unlockSelection();
            }
        }
        return allText;
    };

    function getCustomText(node) {
        var text = "";
        if (node) {
            if (node.type == CKEDITOR.NODE_ELEMENT && node.getName() == 'p') {
                text = '\n';
            } else if (node.type == CKEDITOR.NODE_ELEMENT &&
                (['br', 'ht'].indexOf(node.getName()) != -1 || (node.isBlockBoundary() && node.isEditable()))) {
                text = '\n';
            } else if (node.type == CKEDITOR.NODE_TEXT)
                text = node.getText();
        }
        return text;
    }
    function walkerFromBodyWithoutFakeElements(editor) {
        var rangeToWalk = editor.createRange();
        rangeToWalk.selectNodeContents(editor.document.getBody());
        var walker = new CKEDITOR.dom.walker(rangeToWalk);
        walker.evaluator = CKEDITOR.dom.walker.bogus(true);
        return walker;
    };
    function computeCaretStart(editor, currentSelection, walker, caretRange) {
        if (currentSelection.collapsed) {
            caretRange.collapseEnd();
        } else {
            var rangeToWalk = walker.range,
                node = null;
            rangeToWalk.collapse(true);
            currentSelection.startContainer.type === CKEDITOR.NODE_TEXT ?
                rangeToWalk.setStartAt(currentSelection.startContainer, CKEDITOR.POSITION_BEFORE_START) :
                rangeToWalk.setStart(currentSelection.startContainer, currentSelection.startOffset);

            walker.reset();
            walker.range = rangeToWalk;
            walker.evaluator = CKEDITOR.dom.walker.bogus(true);
            while (node = walker.previous()) {
                walker.remaining = walker.remaining - getCustomText(node).length;
            }
            caretRange.start = walker.remaining + (currentSelection.startContainer.type === CKEDITOR.NODE_TEXT ? currentSelection.startOffset : 0);
        }
    };
    function computeCaretEnd(editor, currentSelection, walker, caretRange) {
        var rangeToWalk = editor.createRange(),
            node = null;
        rangeToWalk.selectNodeContents(editor.document.getBody());
        currentSelection.endContainer.type === CKEDITOR.NODE_TEXT ?
            rangeToWalk.setStartAt(currentSelection.endContainer, CKEDITOR.POSITION_BEFORE_START) :
            rangeToWalk.setStart(currentSelection.endContainer, currentSelection.endOffset);

        walker.range = rangeToWalk
        walker.evaluator = CKEDITOR.dom.walker.bogus(true);
        while (node = walker.previous()) {
            walker.remaining = walker.remaining - getCustomText(node).length;
        }
        caretRange.end = walker.remaining + (currentSelection.endContainer.type === CKEDITOR.NODE_TEXT ? currentSelection.endOffset : 0);
    };
    function getSelectionRange (editor, textLength) {
        var lockSelection = editor.lockSelection();
        if (textLength == undefined) {
            textLength = getAllText(editor).length;
        }
        var currentSelection = editor.getSelection().getRanges(true)[0];
        if (currentSelection == undefined) {
            setSelectionAtTheEnd(editor, textLength);
            currentSelection = editor.getSelection().getRanges(true)[0];
        }

        var caretRange = new INVOX.Range(0, 0),
            walker = new CKEDITOR.dom.walker();
        walker.remaining = textLength;
        if (currentSelection) {
            computeCaretEnd(editor, currentSelection, walker, caretRange);
            computeCaretStart(editor, currentSelection, walker, caretRange);
        }
        if (lockSelection) {
            editor.unlockSelection();
        }
        return caretRange;
    };
    function setSelectionRange (editor, range, textLength) {

        var rangeToSelect = getNodeRange(editor, range, textLength);
        rangeToSelect.select();
    };
    function setSelectionAtTheEnd(editor, textLength) {
        var range = new INVOX.Range(textLength - 1);
        setSelectionRange(editor, range);
    };
    function setStartNode(range, walker, domRange, editor) {
        if (range.collapsed()) {
            domRange.collapse(false);
        } else {
            var node = walker.current;
            walker.remaining += getCustomText(node).length;
            do {
                walker.remaining = walker.remaining - getCustomText(node).length;
            } while (walker.remaining > range.start && (node = walker.previous()))
            if (node) {
                (node.type == CKEDITOR.NODE_ELEMENT) ?
                    domRange.setStartAt(node, (node.isEditable() ?
                        CKEDITOR.POSITION_BEFORE_END :
                        CKEDITOR.POSITION_BEFORE_START)) :
                    domRange.setStart(node, range.start - walker.remaining);
            } else {
                domRange.setStartAt(editor.document.getBody().getChild(0), CKEDITOR.POSITION_AFTER_START);
            }
        }
    };
    function setEndNode(range, walker, domRange, editor) {
        var node = walker.previous();
        do {
            walker.remaining = walker.remaining - getCustomText(node).length;
        } while (walker.remaining > range.end && (node = walker.previous()))

        if (node) {
            (node.type == CKEDITOR.NODE_ELEMENT) ?
                domRange.setEndAt(node, (node.isEditable() ?
                    CKEDITOR.POSITION_BEFORE_END :
                    CKEDITOR.POSITION_BEFORE_START)) :
                domRange.setEnd(node, range.end - walker.remaining);
        } else {
            domRange.setEndAt(editor.document.getBody().getChild(0), CKEDITOR.POSITION_AFTER_START);
        }
    };
    function getNodeRange(editor, range, textLength) {
        var lockSelection = editor.lockSelection();
        var walker = walkerFromBodyWithoutFakeElements(editor),
            domRange = editor.createRange();
        walker.remaining = (textLength !== undefined ? textLength : getAllText(editor).length);
        setEndNode(range, walker, domRange, editor);
        setStartNode(range, walker, domRange, editor);
        if (lockSelection) {
            editor.unlockSelection();
        }
        return domRange;
    };

    return textWriter;
})();
