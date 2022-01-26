import { jsx as _jsx } from "react/jsx-runtime";
export function FileInput(_a) {
    var _b = _a.acceptedFileString, acceptedFileString = _b === void 0 ? "application/pdf" : _b, onChange = _a.onChange;
    return _jsx("input", { id: 'FileUploadForm-input', type: "file", name: "formFile", multiple: true, accept: acceptedFileString, onChange: onChange, role: "input", "data-testid": "FileInput" }, void 0);
}
