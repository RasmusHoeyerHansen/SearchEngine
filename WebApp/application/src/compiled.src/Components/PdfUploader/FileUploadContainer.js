var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { useState } from "react";
import { FileUploadForm } from "./FileUploadForm";
var UploadedFile = function () {
    return _jsx("div", { role: "uploaded files" }, void 0);
};
export var FileUploadContainer = function () {
    var _a = useState(), pdfFiles = _a[0], setState = _a[1];
    var displayText = "Upload a PDF file to contribute to the search engine.";
    var onFileSelectionChanged = function (event) {
        var selectedFiles = [];
        var element = event.currentTarget;
        var fileList = element.files;
        if (fileList) {
            for (var itm in fileList) {
                var item = fileList[itm];
                if (!selectedFiles.includes(item))
                    selectedFiles.push(item);
            }
        }
        setState(selectedFiles);
    };
    var onFileSubmit = function (event) {
    };
    return (_jsxs("div", __assign({ className: "PdfUploadContainer", "data-testid": 'FileUploadContainer' }, { children: [_jsx(FileUploadForm, { onSubmit: onFileSubmit, onChange: onFileSelectionChanged }, void 0), _jsx(UploadedFile, {}, void 0)] }), void 0));
};
export default FileUploadContainer;
