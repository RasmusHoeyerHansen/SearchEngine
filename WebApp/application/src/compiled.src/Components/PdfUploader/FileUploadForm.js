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
import { jsx as _jsx } from "react/jsx-runtime";
import { FileInput } from "./FileInput";
export var FileUploadForm = function (_a) {
    var onChange = _a.onChange, _b = _a.fileTypes, fileTypes = _b === void 0 ? ['application/pdf'] : _b;
    var acceptFileTypes = fileTypes.join(',');
    return _jsx("form", __assign({ id: "FileUploadForm", role: 'form', "data-testid": 'FileUploadForm' }, { children: _jsx(FileInput, { acceptedFileString: acceptFileTypes, onChange: onChange }, void 0) }), void 0);
};
